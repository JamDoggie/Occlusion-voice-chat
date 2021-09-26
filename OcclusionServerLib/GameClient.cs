using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using LiteNetLib;
using OcclusionServerLib.MCNetworking;
using OcclusionServerLib.structs;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OcclusionServerLib
{
    public class GameClient
    {

        public bool Running { get; set; } = false;

        #region events
        public delegate void PacketRecieved(MCPacket packet, GameClient client);
        public event PacketRecieved PacketRecievedEvent;


        private void InternalPacketRecieved(MCPacket packet, GameClient client)
        {
            if (packet is MCServerVerificationPacket)
            {

                var serverVerificationPacket = packet as MCServerVerificationPacket;

                NetPeer connection;

                NetPeer dummyCon;
                Server.codesBeingVerified.TryGetValue(serverVerificationPacket.Code, out dummyCon);

                if (dummyCon != null)
                {
                    Server.codesBeingVerified.Remove(serverVerificationPacket.Code, out connection);

                    if (serverVerificationPacket.Verified)
                    {
                        server.GetUserByConnection(connection).verificationCode = serverVerificationPacket.Code;
                        server.GetUserByConnection(connection).MCUUID = serverVerificationPacket.UUID;
                        server.GetUserByConnection(connection).IsVerified = true;

                        VoiceUser newUser = server.GetUserByConnection(connection);

                        // Check to make sure a verified user with the same uuid isn't connected. If they are, remove the old one.
                        // It's possible the old client crashed, meaning the server is still trying to ping it. Having two different connections of the same person being monitored
                        // can cause problems.
                        for (int i = server.Users.Count - 1; i >= 0; i--)
                        {
                            VoiceUser user = server.Users[i];

                            if (user != newUser && user.MCUUID == newUser.MCUUID)
                            {
                                user.Connection.Disconnect();
                                server.Users.Remove(user);
                            }
                        }

                        // Send this now verified user to everyone connected
                        foreach (VoiceUser user in server.Users)
                        {
                            ServerUserConnectedPacket userConnectedPacket = new ServerUserConnectedPacket();
                            userConnectedPacket.idsToAdd.Add(new KeyValuePair<int, string>(serverVerificationPacket.Code, serverVerificationPacket.UUID));

                            server.SendMessage(userConnectedPacket, user.Connection, DeliveryMethod.ReliableOrdered);
                        }

                        
                    }
                    else
                    {
                        server.SendMessage(new ServerValidationRejected(), connection, DeliveryMethod.ReliableOrdered);
                    }
                }
            }

            if (packet is MCServerPlayerLocation)
            {
                var playerLocationPacket = packet as MCServerPlayerLocation;

                foreach(VoiceUser user in server.Users)
                {
                    if (user.verificationCode == playerLocationPacket.VerificationCode)
                    {
                        user.Location = new PlayerLocation(
                            playerLocationPacket.PosX, 
                            playerLocationPacket.PosY, 
                            playerLocationPacket.PosZ, 
                            playerLocationPacket.Pitch, 
                            playerLocationPacket.Yaw, 
                            playerLocationPacket.World,
                            playerLocationPacket.IsSpectator);

                        break;
                    }
                }

                foreach(VoiceUser user in server.Users)
                {
                    if (user.Location != null)
                    {
                        int newBitrate = 64;

                        // First, we figure out how many players are within hearing range of this user (including this user)
                        int usersInRange = 1; // Start with one and skip calculations for the player we're testing the range on.
                        foreach(VoiceUser userWithin in server.Users)
                        {
                            if (userWithin.Location != null && userWithin != user)
                            {
                                Vector3 userPos = new Vector3(user.Location.Value.PosX, user.Location.Value.PosY, user.Location.Value.PosZ);
                                Vector3 userWithinPos = new Vector3(userWithin.Location.Value.PosX, userWithin.Location.Value.PosY, userWithin.Location.Value.PosZ);

                                if (Vector3.Distance(userPos, userWithinPos) <= server.SettingsFile.Obj.HearingDistance)
                                {
                                    usersInRange++;
                                }
                            }
                        }

                        // If there are at least 5 people in hearing range of this player, lower their bitrate.
                        if (usersInRange >= 5)
                        {
                            // Per user after five, lower the bitrate by one.
                            int overFlow = usersInRange - 5;

                            newBitrate = 32;

                            newBitrate -= overFlow;

                            if (newBitrate < 24)
                                newBitrate = 24; // Clamp the lowest possible bitrate to 24 Kbps (from testing anything too much lower than this sounds ultra-cellphone quality)
                        }

                        newBitrate = 24;


                        if (newBitrate != user.CurrentBitrate)
                        {
                            ServerBitrateChangePacket bitratePacket = new ServerBitrateChangePacket();
                            bitratePacket.NewBitrate = newBitrate;

                            server.SendMessage(bitratePacket, user.Connection, DeliveryMethod.ReliableOrdered);

                            user.CurrentBitrate = newBitrate;
                        }
                    }
                }
            }

            if (packet is MCServerPlayerLeave playerLeave)
            {
                VoiceUser user = server.GetUserByCode(playerLeave.ID);
                
                if (user != null)
                {
                    server.BroadcastMessage(new ServerUserLeftPacket()
                    {
                        UUID = playerLeave.UUID
                    }, DeliveryMethod.ReliableOrdered);

                    server.SendMessage(new ServerDisconnectPacket() { DisconnectMessage = "disconnected from the minecraft server." }, user.Connection, DeliveryMethod.ReliableOrdered);

                    server.Users.Remove(user);
                }
            }
        }
        #endregion

        #region private fields
        private IChannel clientChannel;

        private Server server;

        private GameClientHandler handler;
        #endregion


        public GameClient(Server server)
        {
            MCPacketManager.RegisterPackets();
            PacketRecievedEvent += InternalPacketRecieved;

            this.server = server;
        }

        public async Task Connect(string ip, int serverport)
        {
            if (ip == "localhost")
                ip = "127.0.0.1";

            var eventLoopGroup = new MultithreadEventLoopGroup();

            handler = new GameClientHandler(this);
            
            Bootstrap clientBootstrap = new Bootstrap();
            clientBootstrap.
                Group(eventLoopGroup)
                .Option(ChannelOption.TcpNodelay, true)
                .Channel<TcpSocketChannel>()
                .Handler(new ActionChannelInitializer<TcpSocketChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    
                    pipeline.AddLast(new LengthFieldBasedFrameDecoder(8000000, 0, 3, 0, 3));
                    pipeline.AddLast(new LengthFieldPrepender(3)); // 3 byte int
                    
                    pipeline.AddLast(new GameClientHandler(this));
                }));

            clientChannel = await clientBootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), serverport));

            Server.GameClientLogger.Log("Starting game client connected to port " + serverport);
            

        }

        /// <summary>
        /// Note: only meant for invoking the event, not for outside use.
        /// </summary>
        public void HandlerRecievedPacket(MCPacket packet)
        {
            PacketRecievedEvent.Invoke(packet, this);
        }

        public async void SendMessage(MCPacket packet)
        {
            if (clientChannel != null)
            {
                packet.SendMessage(clientChannel);
                await clientChannel.WriteAndFlushAsync(packet.buffer);
                
            }
                
        }
    }
    public class GameClientHandler : SimpleChannelInboundHandler<IByteBuffer>
    {
        private GameClient client;

        public GameClientHandler(GameClient client)
        {
            this.client = client;
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, IByteBuffer packet)
        {
            try
            {
                
                if (packet.IsReadable() && packet.ReadableBytes >= 4)
                {
                    var packetId = packet.ReadIntLE();

                    if (MCPacketManager.GetPacketTypeById(packetId) != null)
                    {
                        MCPacket mcPacket = (MCPacket)Activator.CreateInstance(MCPacketManager.GetPacketTypeById(packetId));
                        mcPacket.FromMessage(packet);

                        client.HandlerRecievedPacket(mcPacket);
                    }
                }
                
            }
            catch(PacketIDNotFoundException e)
            {
                Server.ServerLogger.Log(e.Message);
            }
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);

            Server.GameClientLogger.Log("Lost connection to game server.");
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Server.ServerLogger.Log("Exception: " + exception);
            context.CloseAsync();
        }
    }
}
