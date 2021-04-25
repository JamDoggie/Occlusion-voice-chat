using Lidgren.Network;
using Newtonsoft.Json;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using OcclusionServerLib;
using OcclusionServerLib.JSON;
using OcclusionServerLib.structs;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using System;
using System.IO;
using System.Numerics;
using System.Threading;

namespace OcclusionDedicatedServer
{
    class Program
    {
        public static Server Server = new Server();


        static void Main(string[] args)
        {
            PacketManager.CollectPacketTypes();

            Thread serverThread = new Thread(() =>
            {
                Server.Start(new SynchronizationContext());
            });


            Server.PacketRecievedEvent += Server_PacketRecievedEvent;

            serverThread.Start();



            Console.ReadKey();
        }

        private static void Server_PacketRecievedEvent(NetIncomingMessage message, IPacket packet, Server server)
        {
            if (packet is ClientVoiceDataPacket)
            {
                var incomingVoice = packet as ClientVoiceDataPacket;
                
                if (server.GetUserByConnection(message.SenderConnection) != null && server.GetUserByConnection(message.SenderConnection).IsVerified)
                {
                    foreach (VoiceUser user in server.Users)
                    {
                        if (server.GetUserByConnection(message.SenderConnection) != null && 
                            user.IsVerified &&
                            user.id != server.GetUserByConnection(message.SenderConnection).id &&
                            user.Location != null &&
                            server.GetUserByConnection(message.SenderConnection).Location != null)
                        {
                            VoiceUser otherUser = server.GetUserByConnection(message.SenderConnection);
                            PlayerLocation otherUserLocation = otherUser.Location.Value;
                            PlayerLocation userLocation = user.Location.Value;

                            // Do some extra checks to make sure we don't send voice data when it's not needed
                            if (otherUserLocation.World == userLocation.World &&
                                (!otherUser.Location.Value.IsSpectator || user.Location.Value.IsSpectator))
                            {
                                // New voice packet to be sent
                                ServerVoiceDataPacket voicePacket = new ServerVoiceDataPacket();
                                voicePacket.VoiceData = incomingVoice.VoiceData;

                                voicePacket.ID = server.GetUserByConnection(message.SenderConnection).id;

                                float maxHearingDistance = 78;

                                // Calculate the volume based on how far this player is from the player we're sending the voice data of
                                Vector3 otherPlayerVec = new Vector3(otherUserLocation.PosX, otherUserLocation.PosY, otherUserLocation.PosZ);
                                Vector3 recievingPlayerVec = new Vector3(userLocation.PosX, userLocation.PosY, userLocation.PosZ);

                                float distance = Vector3.Distance(otherPlayerVec, recievingPlayerVec);

                                voicePacket.Volume = Math.Clamp((maxHearingDistance - distance) / maxHearingDistance, 0, 1);

                                // Calculate the pan using some awful trigonomotry. This is how far left or right the player should hear the other player stereo wise.
                                // -1 = fully in left ear | 0 = fully in center | 1 = fully in right ear
                                // And of course any values in between since it's a float
                                if ((otherPlayerVec - recievingPlayerVec).Length() != 0)
                                {
                                    float xDiff = otherPlayerVec.X - recievingPlayerVec.X;
                                    float yDiff = otherPlayerVec.Z - recievingPlayerVec.Z;

                                    double angle = Math.Atan2(yDiff, xDiff) - ConvertDegreesToRadians(userLocation.Yaw);

                                    // Luckily this -1 to 1 pan system happens to perfectly align with the coordinate system of a circle
                                    voicePacket.Pan = -(float)Math.Cos(angle);
                                }
                                else
                                {
                                    voicePacket.Pan = 0;
                                }


                                // We send as unreliable sequenced because this is where UDP really shines for VoIP.
                                // Since we're sending lots of data over the network and it's not really a huge deal if we drop one packet,
                                // it's better to allow some packets to drop instead of making sure they all arrive at the cost of performance and delay.
                                server.SendMessage(voicePacket, user.Connection, NetDeliveryMethod.UnreliableSequenced);
                            }
                        }
                    }
                }
            }
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
