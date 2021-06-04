using Lidgren.Network;
using Newtonsoft.Json;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using OcclusionDedicatedServer.json;
using OcclusionServerLib.JSON;
using OcclusionServerLib.MCNetworking;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using OcclusionShared.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Timers;

namespace OcclusionServerLib
{
    public class Server
    {
        #region fields
        public int Port { get; set; } = 9755;

        public NetServer LidgrenServer { get; set; }

        public int MaxPlayers { get; set; } = 5;

        public ConcurrentList<VoiceUser> Users { get; set; } = new ConcurrentList<VoiceUser>();

        private int userIdIter = 0;

        // NOTE: THIS IS STATIC FOR THREAD SAFETY
        // Don't ask me why this works this way, but it does.
        public static System.Timers.Timer intervalTimer = new System.Timers.Timer();

        public static ConcurrentDictionary<int, NetConnection> codesBeingVerified = new ConcurrentDictionary<int, NetConnection>();

        public GameClient GameClient;

        public JsonFile<ServerSettings> SettingsFile = new JsonFile<ServerSettings>("settings.json", new ServerSettings());
        #endregion

        #region loggers
        public static Logger ServerLogger { get; set; } = new Logger("[SERVER]");

        public static Logger GameClientLogger { get; set; } = new Logger("[GAME CLIENT]");
        #endregion

        #region events
        public delegate void PacketRecieved(NetIncomingMessage message, IPacket packet, Server server);
        public event PacketRecieved PacketRecievedEvent;

        private void InternalPacketRecieved(NetIncomingMessage message, IPacket packet, Server server)
        {
            // Player Verification
            if (packet is ClientVerificationPacket)
            {
                var verificationPacket = packet as ClientVerificationPacket;

                codesBeingVerified[verificationPacket.VerificationCode] = message.SenderConnection;

                GameClient.SendMessage(new MCClientVerificationPacket() { Code = verificationPacket.VerificationCode });
            }
        }
        #endregion

        public Server()
        {
            GameClient = new GameClient(this);
        }

        public void Start(SynchronizationContext context = null)
        {
            var config = new NetPeerConfiguration(NetworkingUtil.ConfigurationName);
            config.Port = Port;
            config.MaximumConnections = MaxPlayers;
            config.DisableMessageType(NetIncomingMessageType.DebugMessage);
            config.DisableMessageType(NetIncomingMessageType.VerboseDebugMessage);
            config.DisableMessageType(NetIncomingMessageType.WarningMessage);
            config.DisableMessageType(NetIncomingMessageType.Receipt);
            config.AutoFlushSendQueue = false;

            LidgrenServer = new NetServer(config);
            LidgrenServer.Start();

            if (LidgrenServer.Status == NetPeerStatus.Running)
            {
                ServerLogger.Log("Server is now running on port " + config.Port);
            }
            else
            {
                ServerLogger.Log("Failure! Server not running, Something has gone wrong. Check your firewall to make sure it is not blocking any vital connections.");
            }

            LidgrenServer.RegisterReceivedCallback(new SendOrPostCallback(MessageLoop), context);

            PacketRecievedEvent += InternalPacketRecieved;

            intervalTimer.Interval = 1000d / 60d;
            intervalTimer.Start();

            intervalTimer.Elapsed += Tick;

            // Game client
            Thread gameClientThread = new Thread(async () =>
            {
                

                int port = -1;

                int.TryParse(SettingsFile.Obj.GamePort, out port);

                if (SettingsFile.Obj.GameIP != "" && port != -1)
                {
                    await GameClient.Connect(SettingsFile.Obj.GameIP, port);
                }
                else
                {
                    GameClientLogger.Log("Could not start game client, invalid IP or port! Did you set the IP and port in the settings.json file?");
                }
            });

            gameClientThread.Start();
        }

        private DateTime deltaTime = DateTime.Now;
        private DateTime launchTime = DateTime.Now;

        private void Tick(object source, ElapsedEventArgs e)
        {
            // Timing stuff
            DateTime newTime = DateTime.Now;
            TimeSpan timeSpan = newTime - deltaTime;
            deltaTime = DateTime.Now;
        }

        private void MessageLoop(object peer)
        {
            NetIncomingMessage message;
            while ((message = LidgrenServer.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:

                        int internalid = message.ReadInt32();

                        foreach (KeyValuePair<string, Type> pair in PacketManager.PacketIds)
                        {
                            if (PacketManager.GetPacketInternalId(pair.Key) == internalid &&
                                pair.Value.GetInterfaces().Contains(typeof(IPacket)))
                            {
                                IPacket dummyPacket = Activator.CreateInstance(pair.Value) as IPacket;
                                dummyPacket.FromMessage(message);

                                PacketRecievedEvent.Invoke(message, dummyPacket, this);
                            }
                        }

                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        ServerLogger.Log(message.ReadString());
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        ServerLogger.Log(message.SenderConnection.Status.ToString());

                        if (message.SenderConnection.Status == NetConnectionStatus.Connected)
                        {
                            ServerLogger.Log($"{message.SenderConnection.Peer.Configuration.LocalAddress} has connected.");

                            Users.Add(new VoiceUser()
                            {
                                Connection = message.SenderConnection,
                                id = userIdIter
                            });

                            // Send packet to client that tells it we've properly connected
                            ServerConnectedPacket serverConnectedPacket = new ServerConnectedPacket();
                            SendMessage(serverConnectedPacket, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);

                            // Send full list of users to the user that just connected
                            ServerUserConnectedPacket userConnectedPacket = new ServerUserConnectedPacket();
                            userConnectedPacket.idsToAdd = new List<KeyValuePair<int, string>>();
                            foreach (VoiceUser user in Users)
                            {
                                if (user.IsVerified && user != GetUserByConnection(message.SenderConnection))
                                    userConnectedPacket.idsToAdd.Add(new KeyValuePair<int, string>(user.verificationCode, user.MCUUID));
                            }

                            SendMessage(userConnectedPacket, message.SenderConnection, NetDeliveryMethod.ReliableOrdered);


                            userIdIter++;
                        }

                        // Clear everything we need to when a user disconnects
                        if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
                        {
                            if (GetUserByConnection(message.SenderConnection) != null)
                            {
                                ServerUserLeftPacket userLeftPacket = new ServerUserLeftPacket();
                                userLeftPacket.UUID = GetUserByConnection(message.SenderConnection).MCUUID;
                                BroadcastMessage(userLeftPacket, NetDeliveryMethod.ReliableOrdered);

                                Users.Remove(GetUserByConnection(message.SenderConnection));
                            }
                        }
                        break;

                    default:
                        ServerLogger.Log("Unhandled message type: " + message.MessageType);
                        break;
                }
                LidgrenServer.Recycle(message);
            }
        }

        public VoiceUser GetUserById(int id)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.id == id)
                    return user;
            }

            return null;
        }

        public VoiceUser GetUserByCode(int code)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.verificationCode == code)
                    return user;
            }

            return null;
        }

        public VoiceUser GetUserByConnection(NetConnection connection)
        {
            foreach(VoiceUser user in Users)
            {
                if (user.Connection == connection)
                    return user;
            }

            return null;
        }

        public void SendMessage(IPacket packet, NetConnection peer, NetDeliveryMethod method)
        {
            NetOutgoingMessage message = LidgrenServer.CreateMessage();
            packet.ToMessage(message);

            LidgrenServer.SendMessage(message, peer, method);

            LidgrenServer.FlushSendQueue();
        }

        public void BroadcastMessage(IPacket packet, NetDeliveryMethod method)
        {
            foreach (NetConnection peer in LidgrenServer.Connections)
            {
                NetOutgoingMessage message = LidgrenServer.CreateMessage();
                packet.ToMessage(message);
                LidgrenServer.SendMessage(message, peer, method);

                LidgrenServer.FlushSendQueue();
            }
        }
    }
}
