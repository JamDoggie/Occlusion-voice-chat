using Avalonia.Controls;
using Avalonia.Threading;
using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared;
using Occlusion_Voice_Chat_CrossPlatform;
using OcclusionShared.NetworkingShared.Packets;
using OcclusionVersionControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Occlusion_voice_chat.Networking
{
    public class Client
    {
        public EventBasedNetListener EventListener { get; set; } = new EventBasedNetListener();

        public NetManager InternalClient { get; set; }

        public float UpdateRateMS { get; set; } = 16;

        public bool Running { get; set; } = false;

        public bool ConnectionVerified { get; set; } = false;

        public int verificationCode { get; set; } = -1;

        #region Events
        public delegate void PacketRecieved(NetPacketReader message, IPacket packet, Client client);
        public event PacketRecieved PacketRecievedEvent;


        private NetDataWriter writer = new NetDataWriter();

        private void InternalPacketRecieved(NetPacketReader message, IPacket packet, Client client)
        {
            if (packet is ServerConnectedPacket connectedPacket)
            {
                if (connectedPacket.OcclusionVersion == OcclusionVersion.VersionNumber)
                {
                    var clientVerification = new ClientVerificationPacket();
                    clientVerification.VerificationCode = verificationCode;

                    App.EnableVoiceIconMeterOnClients = connectedPacket.EnableVoiceIconMeterOnClients;

                    SendMessage(clientVerification, DeliveryMethod.ReliableOrdered);
                }
                else
                {
                    if (connectedPacket.OcclusionVersion > OcclusionVersion.VersionNumber)
                    {
                        // Server is more up to date than the client.
                        DisconnectClient("server is on a newer version than your client. Please update Occlusion if you would like to connect to this server.");
                    }
                    else if(connectedPacket.OcclusionVersion < OcclusionVersion.VersionNumber)
                    {
                        // Client is more up to date than the server.
                        DisconnectClient("server is out of date. Please contact the server owner to update the server.");
                    }
                }
            }

            if (packet is ServerValidationRejected)
            {
                DisconnectClient("Code validation rejected", false);
            }

            if (packet is ServerDisconnectPacket disconnectPacket)
            {
                DisconnectClient(disconnectPacket.DisconnectMessage, true);
            }

            if (packet is AutoDisconnectPacket autoDisconnect)
            {
                Dispatcher.UIThread.InvokeAsync(() => 
                { 
                    if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                    {
                        MainWindow.mainWindow.VoiceChatWindow.AutoDisconnectScreen.IsVisible = autoDisconnect.ShowWarning;
                        MainWindow.mainWindow.VoiceChatWindow.AutoDisconnectSeconds = (int)autoDisconnect.SecondsTillDisconnect;
                    }
                });
            }
        }
        #endregion


        public Client()
        {
            PacketManager.CollectPacketTypes();

            PacketRecievedEvent += InternalPacketRecieved;

            InternalClient = new NetManager(EventListener);


            // Handle data packets.
            EventListener.NetworkReceiveEvent += (fromPeer, dataReader, deliveryMethod) =>
            {
                int internalid = dataReader.GetInt();

                foreach (KeyValuePair<string, Type> pair in PacketManager.PacketIds)
                {
                    if (PacketManager.GetPacketInternalId(pair.Key) == internalid)
                    {
                        if (PacketManager.PooledPackets.TryGetValue(pair.Key, out IPacket pooledPacket))
                        {
                            // Use a pre-pooled packet object for this packet type.
                            pooledPacket.FromMessage(dataReader);

                            PacketRecievedEvent.Invoke(dataReader, pooledPacket, this);
                        }
                        else
                        {
                            IPacket dummyPacket = Activator.CreateInstance(pair.Value) as IPacket;
                            dummyPacket.FromMessage(dataReader);

                            PacketRecievedEvent.Invoke(dataReader, dummyPacket, this);
                        }
                    }
                }

                dataReader.Recycle();
            };

            // Remove the loading text when we're connected.
            EventListener.PeerConnectedEvent += (peer) =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (MainWindow.mainWindow != null)
                    {
                        MainWindow.mainWindow.ConnectionStatusText.Text = string.Empty;
                        MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = false;
                    }
                });
            };

            // Tell the user why they got disconnected if we need to, and close the voice chat window.
            EventListener.PeerDisconnectedEvent += (peer, info) =>
            {
                string reason = info.Reason.ToString();
                string errorMessage = "";
                if (string.IsNullOrEmpty(reason))
                {
                    errorMessage = "Disconnected";
                }
                else
                {
                    errorMessage = $"Disconnected, Reason: {reason}";
                }

                string subtitle = "";

                if (info.AdditionalData.RawDataSize > 0)
                {
                    subtitle = $"{Encoding.UTF8.GetString(info.AdditionalData.GetRemainingBytes())}";
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine(subtitle);

                // Now we update the UI to reflect we were disconnected.
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                    {
                        MainWindow.mainWindow.VoiceChatWindow.Close();
                    }

                    if (MainWindow.mainWindow != null)
                    {
                        MainWindow.mainWindow.ShowErrorMessage(errorMessage, subtitle);
                        MainWindow.mainWindow.ConnectionStatusText.Text = "Server connection lost or failed.";
                        MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = false;
                    }
                });

                Running = false;
            };

            EventListener.NetworkLatencyUpdateEvent += (peer, latency) => 
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                    {
                        var tip = MainWindow.mainWindow.VoiceChatWindow.FindControl<TextBlock>("InfoToolTipText");
                        tip.Text = $"Ping: {latency}ms";
                    }
                });
            };
        }

        public void Connect(string ip, int serverport, int verificationCode)
        {
            InternalClient.Start();

            NetDataWriter connectionData = new NetDataWriter();
            connectionData.Put("OcclusionVoiceClient");
            connectionData.Put(OcclusionVersion.VersionNumber);

            InternalClient.Connect(ip, serverport, connectionData);

            // Start connecting animation.
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (MainWindow.mainWindow != null)
                {
                    MainWindow.mainWindow.ConnectingLoadingBar.IsVisible = true;
                    MainWindow.mainWindow.ConnectionStatusText.Text = "Connecting...";
                }
            });

            this.verificationCode = verificationCode;

            Running = true;

            

            while (Running)
            {
                InternalClient.PollEvents();
                Thread.Sleep(1);
            }
        }

        /*public void DoMessageLoop()
        {
            // Message loop, this is where we intercept packets.
            NetIncomingMessage message;
            while ((message = InternalClient.ReadMessage()) != null)
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
                        float latency = message.ReadFloat();

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
        }*/

        public void DisconnectClient(string reason, bool showReasonMessageBox = true)
        {
            InternalClient.DisconnectAll();
            InternalClient.Stop();
            Running = false;
            ConnectionVerified = false;

            App.Users.Clear();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                {
                    MainWindow.mainWindow.VoiceChatWindow.Close();
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
                if (InternalClient == null)
                    return false;

                return InternalClient.ConnectedPeersCount > 0;
            }
        }

        public void SendMessage(IPacket packet, DeliveryMethod method)
        {
            writer.Reset();
            packet.ToMessage(writer);
            InternalClient.SendToAll(writer, method);
        }
    }
}
