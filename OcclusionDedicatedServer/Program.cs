﻿using LiteNetLib;
using LiteNetLib.Utils;
using NBrigadier;
using NBrigadier.Builder;
using NBrigadier.Exceptions;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using OcclusionServerLib;
using OcclusionServerLib.structs;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using System;
using System.Numerics;
using System.Threading;

namespace OcclusionDedicatedServer
{
    class Program
    {
        public static Server Server = new Server();

        public static bool IsRunning = true;

        private static CommandContext _commandSource = new CommandContext();

        static void Main(string[] args)
        {
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += CurrentDomain_UnhandledException; 

            PacketManager.CollectPacketTypes();

            Thread serverThread = new Thread(() =>
            {
                Server.Start(new SynchronizationContext());
            });


            Server.PacketRecievedEvent += Server_PacketRecievedEvent;

            serverThread.Start();



            CommandDispatcher<CommandContext> cmdDispatcher = new CommandDispatcher<CommandContext>();

            cmdDispatcher.Register(
                LiteralArgumentBuilder<CommandContext>.Literal("stop")
                .Executes(c =>
                {
                    Server.ServerLogger.Log("Stopping server...");

                    foreach(VoiceUser user in Server.Users)
                    {
                        ServerDisconnectPacket disconnectPacket = new ServerDisconnectPacket();
                        disconnectPacket.DisconnectMessage = "Server stopped.";

                        Server.SendMessage(disconnectPacket, user.Connection, DeliveryMethod.ReliableOrdered);
                    }

                    Server.InternalServer.Stop();

                    IsRunning = false;

                    return 1;
                }));

            cmdDispatcher.Register(
                LiteralArgumentBuilder<CommandContext>.Literal("reloadconfig")
                .Executes(c =>
                {
                    Server.SettingsFile.ReloadFromFile();

                    Server.ServerLogger.Log("Successfully reloaded config.");

                    return 1;
                }));

            while (IsRunning)
            {
                string userInput = Console.ReadLine();

                try
                {
                    Server.ServerLogger.Log($">{userInput}");

                    cmdDispatcher.Execute(userInput, _commandSource);
                }
                catch(CommandSyntaxException e)
                {
                    Server.ServerLogger.Log(e.Message);
                }
                
            }
            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                string logFile = $"{ex.Message}\n\nSTACK TRACE:\n{ex.StackTrace}";
                System.IO.File.WriteAllText($"occlusioncrashlog-{string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", DateTime.Now)}.txt", logFile);
            }
        }

        private static void Server_PacketRecievedEvent(NetDataReader message, IPacket packet, Server server, NetPeer peer)
        {
            if (packet is ClientVoiceDataPacket)
            {
                var incomingVoice = packet as ClientVoiceDataPacket;
                
                if (server.GetUserByConnection(peer) != null && server.GetUserByConnection(peer).IsVerified)
                {
                    foreach (VoiceUser user in server.Users)
                    {
                        if (server.GetUserByConnection(peer) != null && 
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
                                server.SendMessage(voicePacket, user.Connection, DeliveryMethod.Unreliable);                            }
                        }
                    }
                }
            }
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
