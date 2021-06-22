using Avalonia.Controls;
using Avalonia.Threading;
using Lidgren.Network;
using Occlusion.NetworkingShared;
using Occlusion_Voice_Chat_CrossPlatform;
using OcclusionShared.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Occlusion_voice_chat.Networking
{
    public class Client
    {
        public NetClient LidgrenClient { get; set; }

        public float UpdateRateMS { get; set; } = 16;

        public bool Running { get; set; } = false;

        public bool ConnectionVerified { get; set; } = false;

        public int verificationCode { get; set; } = -1;

        #region Events
        public delegate void PacketRecieved(NetIncomingMessage message, IPacket packet, Client client);
        public event PacketRecieved PacketRecievedEvent;


        private void InternalPacketRecieved(NetIncomingMessage message, IPacket packet, Client client)
        {
            if (packet is ServerConnectedPacket connectedPacket)
            {
                var clientVerification = new ClientVerificationPacket();
                clientVerification.VerificationCode = verificationCode;

                App.EnableVoiceIconMeterOnClients = connectedPacket.EnableVoiceIconMeterOnClients;

                SendMessage(clientVerification, NetDeliveryMethod.ReliableOrdered);
            }

            if (packet is ServerValidationRejected)
            {
                DisconnectClient("Code validation rejected", false);
            }

            if (packet is ServerDisconnectPacket disconnectPacket)
            {
                DisconnectClient(disconnectPacket.DisconnectMessage, true);
            }
        }
        #endregion


        public Client()
        {
            PacketManager.CollectPacketTypes();

            PacketRecievedEvent += InternalPacketRecieved;
        }

        public void Connect(string ip, int serverport, int verificationCode)
        {
            var config = new NetPeerConfiguration(NetworkingUtil.ConfigurationName);
            config.AutoFlushSendQueue = true;
            config.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionApproval, true);
            config.SetMessageTypeEnabled(NetIncomingMessageType.Error, true);
            config.SetMessageTypeEnabled(NetIncomingMessageType.ErrorMessage, true);
            config.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionLatencyUpdated, true);

            LidgrenClient = new NetClient(config);

            LidgrenClient.Start();

            LidgrenClient.Connect(ip, serverport);

            this.verificationCode = verificationCode;

            Running = true;

            while (Running)
            {
                DoMessageLoop();
            }
        }

        public void DoMessageLoop()
        {
            // Message loop, this is where we intercept packets.
            NetIncomingMessage message;
            while ((message = LidgrenClient.ReadMessage()) != null)
            {

                switch (message.MessageType)
                {
                    // Data packets
                    case NetIncomingMessageType.Data:
                        int internalid = message.ReadInt32();

                        foreach (KeyValuePair<string, Type> pair in PacketManager.PacketIds)
                        {
                            if (PacketManager.GetPacketInternalId(pair.Key) == internalid)
                            {
                                var dummyPacket = Activator.CreateInstance(pair.Value) as IPacket;

                                dummyPacket.FromMessage(message);

                                PacketRecievedEvent.Invoke(message, dummyPacket, this);
                            }
                        }

                        break;

                    // The below packet types are either lidgren related or unhandled.
                    case NetIncomingMessageType.StatusChanged:
                        // Status messages
                        NetConnectionStatus statusType = (NetConnectionStatus)message.ReadByte();
                        
                        switch (statusType)
                        {
                            // When connected to the server
                            case NetConnectionStatus.Connected:
                                Dispatcher.UIThread.InvokeAsync(() =>
                                {
                                    if (MainWindow.mainWindow != null)
                                    {
                                        MainWindow.mainWindow.ConnectionStatusText.Text = string.Empty;
                                        MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = false;
                                    }
                                });

                                break;

                            // When disconnected from the server
                            case NetConnectionStatus.Disconnected:
                                string reason = message.ReadString();
                                string errorMessage = "";
                                if (string.IsNullOrEmpty(reason))
                                {
                                    errorMessage = "Disconnected";
                                }
                                else
                                {
                                    errorMessage = $"Disconnected, Reason: {reason}";
                                }

                                Console.WriteLine(errorMessage);


                                // Now we update the UI to reflect we were disconnected.
                                Dispatcher.UIThread.InvokeAsync(() =>
                                {
                                    if (App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen)
                                    {
                                        App.VoiceChatWindow.ForceClose = true;
                                        App.VoiceChatWindow.Close();
                                        App.VoiceChatWindow = new VoiceChatWindow();
                                    }

                                    if (MainWindow.mainWindow != null)
                                    {
                                        MainWindow.mainWindow.ShowErrorMessage(errorMessage);
                                        MainWindow.mainWindow.ConnectionStatusText.Text = "Server connection lost or failed.";
                                        MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = false;
                                    }
                                });

                                Running = false;
                                break;
                            
                            case NetConnectionStatus.InitiatedConnect:
                                Dispatcher.UIThread.InvokeAsync(() =>
                                {
                                    if (MainWindow.mainWindow != null)
                                    {
                                        MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = true;
                                        MainWindow.mainWindow.ConnectionStatusText.Text = "Connecting...";
                                    }
                                });
                                break;
                            
                            
                        }
                        
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        // Debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine(message.ReadString());
                        break;

                    case NetIncomingMessageType.WarningMessage:
                        Console.WriteLine(message.ReadString());
                        break;

                    case NetIncomingMessageType.ConnectionApproval:
                        
                        break;

                    case NetIncomingMessageType.Error:
                    case NetIncomingMessageType.ErrorMessage:
                        Console.WriteLine(message.ReadString());
                        break;

                    case NetIncomingMessageType.ConnectionLatencyUpdated:
                        int latency = (int)message.ReadFloat(); 

                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            if (App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen)
                            {
                                var tip = App.VoiceChatWindow.FindControl<TextBlock>("InfoToolTipText");
                                tip.Text = $"Ping: {latency}ms";
                                
                                
                            }
                        });
                        
                        break;

                    // Unhandled message type
                    default:
                        Console.WriteLine("unhandled message with type: "
                            + message.MessageType);
                        break;
                }
            }
        }

        public void DisconnectClient(string reason, bool showReasonMessageBox = true)
        {
            LidgrenClient.Disconnect(reason);
            Running = false;
            ConnectionVerified = false;

            App.Users.Clear();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen)
                {
                    App.VoiceChatWindow.ForceClose = true; // This bypasses the "are you sure you want to disconnect" message box.
                    App.VoiceChatWindow.Close();
                    App.VoiceChatWindow = new VoiceChatWindow();
                }
            });

            if (showReasonMessageBox)
            {

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (MainWindow.mainWindow != null)
                    {
                        MainWindow.mainWindow.ShowErrorMessage($"Disconnected. Reason: {reason}");
                    }   
                });
            }
        }

        private object _isConnectedLock = new object();
        public bool IsConnected()
        {
            lock(_isConnectedLock)
            {
                if (LidgrenClient == null)
                    return false;

                return LidgrenClient.ConnectionStatus == NetConnectionStatus.Connected;
            }
        }

        public void SendMessage(IPacket packet, NetDeliveryMethod method)
        {
            NetOutgoingMessage message = LidgrenClient.CreateMessage();
            packet.ToMessage(message);
            LidgrenClient.SendMessage(message, method);
        }
    }
}
