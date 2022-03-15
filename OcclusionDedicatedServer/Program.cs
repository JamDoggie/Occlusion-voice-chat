using LiteNetLib;
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
    }
}
