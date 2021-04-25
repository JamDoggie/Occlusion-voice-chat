using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Lidgren.Network;
using OcclusionServerLib.MCNetworking;
using OcclusionServerLib.structs;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Net;
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
                Console.WriteLine("got verification packet");

                var serverVerificationPacket = packet as MCServerVerificationPacket;

                NetConnection connection;

                NetConnection dummyCon;
                Server.codesBeingVerified.TryGetValue(serverVerificationPacket.Code, out dummyCon);

                if (dummyCon != null)
                {
                    Server.codesBeingVerified.Remove(serverVerificationPacket.Code, out connection);

                    if (serverVerificationPacket.Verified)
                    {
                        server.GetUserByConnection(connection).verificationCode = serverVerificationPacket.Code;
                        server.GetUserByConnection(connection).MCUUID = serverVerificationPacket.UUID;
                        server.GetUserByConnection(connection).IsVerified = true;

                        // Send this now verified user to everyone connected
                        foreach(VoiceUser user in server.Users)
                        {
                            ServerUserConnectedPacket userConnectedPacket = new ServerUserConnectedPacket();
                            userConnectedPacket.idsToAdd.Add(new KeyValuePair<int, string>(serverVerificationPacket.Code, serverVerificationPacket.UUID));

                            server.SendMessage(userConnectedPacket, user.Connection, NetDeliveryMethod.ReliableOrdered);
                        }
                    }
                    else
                    {
                        server.SendMessage(new ServerValidationRejected(), connection, NetDeliveryMethod.ReliableOrdered);
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

                //Console.WriteLine($"{playerLocationPacket.PosX} {playerLocationPacket.PosY} {playerLocationPacket.PosZ} {playerLocationPacket.Pitch} {playerLocationPacket.Yaw} {playerLocationPacket.World}");
            }

            if (packet is MCServerPlayerLeave playerLeave)
            {
                VoiceUser user = server.GetUserByCode(playerLeave.ID);
                
                if (user != null)
                {
                    server.BroadcastMessage(new ServerUserLeftPacket()
                    {
                        UUID = playerLeave.UUID
                    }, NetDeliveryMethod.ReliableOrdered);

                    server.SendMessage(new ServerDisconnectPacket() { DisconnectMessage = "disconnected from the minecraft server." }, user.Connection, NetDeliveryMethod.ReliableOrdered);

                    server.Users.Remove(user);

                    Console.WriteLine("got leave packet");
                }
                else
                {
                    Console.WriteLine($"mismatched id {playerLeave.ID}");
                }

                
            }

            //Console.WriteLine("PACKET GOT");
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

                    pipeline.AddLast(new LengthFieldBasedFrameDecoder(100000000, 0, 4, 0, 4));
                    pipeline.AddLast(new LengthFieldPrepender(4));
                    
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
                Console.WriteLine(e.Message);
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}
