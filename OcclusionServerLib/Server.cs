using LiteNetLib;
using LiteNetLib.Utils;
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

        public EventBasedNetListener EventListener { get; set; } = new EventBasedNetListener();

        public NetManager InternalServer { get; set; }

        public ConcurrentList<VoiceUser> Users { get; set; } = new ConcurrentList<VoiceUser>();

        private int userIdIter = 0;

        // NOTE: THIS IS STATIC FOR THREAD SAFETY
        // Don't ask me why this works this way, but according to stackoverflow it does.
        public static System.Timers.Timer intervalTimer = new System.Timers.Timer();

        public static ConcurrentDictionary<int, NetPeer> codesBeingVerified = new ConcurrentDictionary<int, NetPeer>();

        public GameClient GameClient;

        public JsonFile<ServerSettings> SettingsFile = new JsonFile<ServerSettings>("settings.json", new ServerSettings());
        #endregion

        #region loggers
        public static Logger ServerLogger { get; set; } = new Logger("[SERVER]");

        public static Logger GameClientLogger { get; set; } = new Logger("[GAME CLIENT]");
        #endregion

        #region events
        public delegate void PacketRecieved(NetPacketReader message, IPacket packet, Server server, NetPeer peer);
        public event PacketRecieved PacketRecievedEvent;

        private NetDataWriter writer = new NetDataWriter();


        private Random random = new Random();
        private void InternalPacketRecieved(NetPacketReader message, IPacket packet, Server server, NetPeer peer)
        {
            // Player Verification
            if (packet is ClientVerificationPacket)
            {
                var verificationPacket = packet as ClientVerificationPacket;

#if DEVMODE
                // DEVMODE:
                //  This code is for testing purposes and will only compile with the DEVMODE compiler word.
                //  This is so I can easily open a ton of occlusion clients and connect to a server without needing
                //  to be in minecraft or have a bunch of minecraft alt accounts.

                var voiceUser = server.GetUserByConnection(peer);
                voiceUser.verificationCode = random.Next(0,100000);
                voiceUser.MCUUID = Guid.NewGuid().ToString();
                voiceUser.IsVerified = true;
                voiceUser.Location = new structs.PlayerLocation(0, 0, 0, 0, 0, "devworld", false);

                // Send this now verified user to everyone connected
                foreach (VoiceUser user in server.Users)
                {
                    ServerUserConnectedPacket userConnectedPacket = new ServerUserConnectedPacket();
                    userConnectedPacket.idsToAdd.Add(new KeyValuePair<int, string>(voiceUser.verificationCode, voiceUser.MCUUID));

                    server.SendMessage(userConnectedPacket, user.Connection, DeliveryMethod.ReliableOrdered);
                }

                return; // Prevent normal behavior if this compiles.
#endif


                codesBeingVerified[verificationPacket.VerificationCode] = peer;

                GameClient.SendMessage(new MCClientVerificationPacket() { Code = verificationPacket.VerificationCode });
            }
        }
        #endregion

        public Server()
        {
            GameClient = new GameClient(this);
            SettingsFile.Update();
            InternalServer = new NetManager(EventListener);
        }

        public void Start(SynchronizationContext context = null)
        {
            InternalServer = new NetManager(EventListener);
            InternalServer.Start(SettingsFile.Obj.ServerPort);

            if (InternalServer.IsRunning)
            {
                ServerLogger.Log("Server is now running on port " + InternalServer.LocalPort);
            }
            else
            {
                ServerLogger.Log("Failure! Server not running, Something has gone wrong. Check your firewall to make sure it is not blocking any vital connections.");
            }

            PacketRecievedEvent += InternalPacketRecieved;

            EventListener.NetworkReceiveEvent += (peer, reader, delivery) => 
            {
                int internalid = reader.GetInt();

                foreach (KeyValuePair<string, Type> pair in PacketManager.PacketIds)
                {
                    if (PacketManager.GetPacketInternalId(pair.Key) == internalid &&
                        pair.Value.GetInterfaces().Contains(typeof(IPacket)))
                    {
                        if (PacketManager.PooledPackets.TryGetValue(pair.Key, out IPacket pooledPacket))
                        {
                            // Use a pre-pooled packet object for this packet type.
                            pooledPacket.FromMessage(reader);

                            PacketRecievedEvent.Invoke(reader, pooledPacket, this, peer);
                        }
                        else
                        {
                            IPacket dummyPacket = Activator.CreateInstance(pair.Value) as IPacket;
                            dummyPacket.FromMessage(reader);

                            PacketRecievedEvent.Invoke(reader, dummyPacket, this, peer);
                        }
                    }
                }

                reader.Recycle();
            };

            EventListener.ConnectionRequestEvent += (request) => 
            {
                var netPeer = request.Accept();

                ServerLogger.Log($"{netPeer.EndPoint.Address} has connected.");

                Users.Add(new VoiceUser()
                {
                    Connection = netPeer,
                    id = userIdIter
                });

                // Send packet to client that tells it we've properly connected as well as tells the client about the server's settings.
                ServerConnectedPacket serverConnectedPacket = new ServerConnectedPacket();
                serverConnectedPacket.EnableVoiceIconMeterOnClients = SettingsFile.Obj.EnableVoiceIconMeterOnClients;
                SendMessage(serverConnectedPacket, netPeer, DeliveryMethod.ReliableOrdered);

                // Send full list of users to the user that just connected
                ServerUserConnectedPacket userConnectedPacket = new ServerUserConnectedPacket();
                userConnectedPacket.idsToAdd = new List<KeyValuePair<int, string>>();
                foreach (VoiceUser user in Users)
                {
                    if (user.IsVerified && user != GetUserByConnection(netPeer))
                        userConnectedPacket.idsToAdd.Add(new KeyValuePair<int, string>(user.verificationCode, user.MCUUID));
                }

                SendMessage(userConnectedPacket, netPeer, DeliveryMethod.ReliableOrdered);


                userIdIter++;
            };

            EventListener.PeerDisconnectedEvent += (peer, info) =>
            {
                if (GetUserByConnection(peer) != null)
                {
                    ServerUserLeftPacket userLeftPacket = new ServerUserLeftPacket();
                    userLeftPacket.UUID = GetUserByConnection(peer).MCUUID;
                    BroadcastMessage(userLeftPacket, DeliveryMethod.ReliableOrdered);

                    Users.Remove(GetUserByConnection(peer));
                }
            };

            intervalTimer.Interval = 1000d / 60d;
            intervalTimer.Start();

            intervalTimer.Elapsed += Tick;

            // Game client
            Thread gameClientThread = new Thread(async () =>
            {
                int port = -1;

                int.TryParse(SettingsFile.Obj.GamePort, out port);

                if (SettingsFile.Obj.GameIP != string.Empty && port != -1)
                {
                    await GameClient.Connect(SettingsFile.Obj.GameIP, port);
                }
                else
                {
                    GameClientLogger.Log("Could not start game client, invalid IP or port! Did you set the IP and port in the settings.json file?");
                }
            });

            gameClientThread.Start();

            while (InternalServer.IsRunning)
            {
                InternalServer.PollEvents();
                Thread.Sleep(1);
            }
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

        public VoiceUser GetUserByConnection(NetPeer connection)
        {
            foreach(VoiceUser user in Users)
            {
                if (user.Connection == connection)
                    return user;
            }

            return null;
        }

        public void SendMessage(IPacket packet, NetPeer peer, DeliveryMethod method)
        {
            writer.Reset();
            packet.ToMessage(writer);
            peer.Send(writer, method);
            
        }

        public void BroadcastMessage(IPacket packet, DeliveryMethod method)
        {
            writer.Reset();
            packet.ToMessage(writer);
            InternalServer.SendToAll(writer, method);
        }
    }
}
