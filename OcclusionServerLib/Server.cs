using LiteNetLib;
using LiteNetLib.Utils;
using Newtonsoft.Json;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using OcclusionDedicatedServer.json;
using OcclusionServerLib.JSON;
using OcclusionServerLib.MCNetworking;
using OcclusionServerLib.structs;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using OcclusionShared.Util;
using OcclusionVersionControl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
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

        public static ConcurrentDictionary<int, NetPeer> codesBeingVerified = new ConcurrentDictionary<int, NetPeer>();

        public GameClient GameClient;

        public static float IdleKickLength = 600; // In seconds

        public static JsonFile<ServerSettings> SettingsFile = new JsonFile<ServerSettings>("settings.json", new ServerSettings());
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
                voiceUser.Location = new PlayerLocation(0, 0, 0, 0, 0, "devworld", false);

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


            // Player voice data
            if (packet is ClientVoiceDataPacket)
            {
                var incomingVoice = packet as ClientVoiceDataPacket;

                if (server.GetUserByConnection(peer) != null && server.GetUserByConnection(peer).IsVerified)
                {
                    foreach (VoiceUser user in server.Users)
                    {
                        if (GameClient.Connected &&
                            server.GetUserByConnection(peer) != null &&
                            user.IsVerified &&
#if !LOOPBACK  
                            user.id != server.GetUserByConnection(peer).id &&
#endif
                            user.Location != null &&
                            server.GetUserByConnection(peer).Location != null)
                        {
                            VoiceUser otherUser = server.GetUserByConnection(peer);
                            PlayerLocation otherUserLocation = otherUser.Location.Value;
                            PlayerLocation userLocation = user.Location.Value;

                            // Do some extra checks to make sure we don't send voice data when it's not needed
                            if (otherUserLocation.World == userLocation.World &&
                                (!otherUser.Location.Value.IsSpectator || user.Location.Value.IsSpectator))
                            {
                                // New voice packet to be sent
                                ServerVoiceDataPacket voicePacket = new ServerVoiceDataPacket();
                                voicePacket.VoiceData = incomingVoice.VoiceData;

                                voicePacket.ID = server.GetUserByConnection(peer).verificationCode;

                                float maxHearingDistance = Server.SettingsFile.Obj.HearingDistance;

                                // Calculate the volume based on how far this player is from the player we're sending the voice data of
                                Vector3 otherPlayerVec = new Vector3(otherUserLocation.PosX, otherUserLocation.PosY, otherUserLocation.PosZ);
                                Vector3 recievingPlayerVec = new Vector3(userLocation.PosX, userLocation.PosY, userLocation.PosZ);

                                float distance = Vector3.Distance(otherPlayerVec, recievingPlayerVec);

                                // This gives us a linear volume based on distance
                                voicePacket.Volume = Math.Clamp((maxHearingDistance - distance) / maxHearingDistance, 0, 1);

                                // Now we make the distance value based on a power curve, since linear scales don't quite sound right
                                voicePacket.Volume = (float)ExpScale(voicePacket.Volume, 0.4, 1);

                                // Calculate the pan using some trigonomotry. This is how far left or right the player should hear the other player stereo wise.
                                // -1 = fully in left ear | 0 = fully in center | 1 = fully in right ear
                                // And of course any values in between since it's a float
                                if ((otherPlayerVec - recievingPlayerVec).Length() != 0)
                                {
                                    float xDiff = otherPlayerVec.X - recievingPlayerVec.X;
                                    float yDiff = otherPlayerVec.Z - recievingPlayerVec.Z;

                                    double angle = Math.Atan2(yDiff, xDiff) - ConvertDegreesToRadians(userLocation.Yaw);

                                    // Luckily this -1 to 1 pan system happens to almost perfectly align with the coordinate system of a circle
                                    voicePacket.Pan = -(float)Math.Cos(angle);

                                    // HRTF calculations
                                    // Azimuth (horizontal rotation from player)
                                    double degrees = ConvertRadiansToDegrees(angle);

                                    degrees -= 90;

                                    degrees = NormalizeEulerAngle(degrees);

                                    if (degrees > 180)
                                    {
                                        degrees = -(360 - degrees);
                                    }

                                    voicePacket.HRTFAzimuth = (float)degrees; // -180 to 180 degrees.

                                    Vector3 playerDiff = (otherPlayerVec - recievingPlayerVec);

                                    voicePacket.HRTFElevation = (float)ConvertRadiansToDegrees(Math.Asin(playerDiff.Y / playerDiff.Length()));
                                }
                                else
                                {
                                    voicePacket.Pan = 0;
                                }

                                // We send as unreliable because this is where UDP really shines for VoIP.
                                // Since we're sending lots of data over the network and it's not really a huge deal if we drop one packet,
                                // it's better to allow some packets to drop instead of making sure they all arrive at the cost of performance and delay.
                                server.SendMessage(voicePacket, user.Connection, DeliveryMethod.Unreliable);
                            }
                        }
                    }
                }
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
                string tag = request.Data.GetString();
                if (tag == "OcclusionVoiceClient")
                {
                    int version = request.Data.GetInt();

                    if (version < OcclusionVersion.VersionNumber)
                    {
                        request.Reject(Encoding.UTF8.GetBytes($"Outdated client (server is on v{OcclusionVersion.VersionNumber}, client is on v{version}). Please update Occlusion."));
                    }

                    if (version > OcclusionVersion.VersionNumber)
                    {
                        request.Reject(Encoding.UTF8.GetBytes($"Outdated server (server is on v{OcclusionVersion.VersionNumber}, client is on v{version}). Please contact the server administrator as this is most likely a mistake."));
                    }

                    if (version != OcclusionVersion.VersionNumber)
                        return;

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
                }

                
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
                Tick();
                Thread.Sleep(1);
            }
        }

        private DateTime oldDelta = DateTime.Now;
        private DateTime launchTime = DateTime.Now;

        private void Tick()
        {
            // Timing stuff
            DateTime newDelta = DateTime.Now;
            TimeSpan deltaTime = newDelta - oldDelta;

            foreach(VoiceUser user in Users)
            {
                if (!user.IsVerified && user.AutoDisconnectCount >= 0)
                {
                    if (user.AutoDisconnectCount != 0)
                    {
                        user.AutoDisconnectCount -= (float)deltaTime.TotalSeconds;
                        if (user.AutoDisconnectCount < 0)
                            user.AutoDisconnectCount = 0;
                    }
                    else
                    {
                        // Kick the user for being idle
                        InternalServer.DisconnectPeer(user.Connection, Encoding.UTF8.GetBytes("Kicked for idling while not connected to the game server. Please join back via Occlusion with a valid code once you're logged in to the game."));
                    }
                }
            }

            // Should always be last.
            oldDelta = DateTime.Now;
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

        public static double NormalizeEulerAngle(double angle)
        {
            double normalized = angle % 360;
            if (normalized < 0)
                normalized += 360;
            return normalized;
        }

        /// <summary>
        /// Scale a linear range between 0.0-1.0 to an exponential scale using the equation returnValue = A + B * Math.Exp(C * inputValue);
        /// </summary>
        /// <param name="inoutValue">The value to scale</param>
        /// <param name="midValue">The value returned for input value of 0.5</param>
        /// <param name="maxValue">The value to be returned for input value of 1.0</param>
        /// <returns></returns>
        private static double ExpScale(double inputValue, double midValue, double maxValue)
        {
            double returnValue = 0;
            if (inputValue < 0 || inputValue > 1) throw new ArgumentOutOfRangeException("Input value must be between 0 and 1.0");
            if (midValue <= 0 || midValue >= maxValue) throw new ArgumentOutOfRangeException("MidValue must be greater than 0 and less than MaxValue");
            // returnValue = A + B * Math.Exp(C * inputValue);
            double M = maxValue / midValue;
            double C = Math.Log(Math.Pow(M - 1, 2));
            double B = maxValue / (Math.Exp(C) - 1);
            double A = -1 * B;
            returnValue = A + B * Math.Exp(C * inputValue);
            return returnValue;
        }

        private static double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }

        private static double ConvertDegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
    }
}
