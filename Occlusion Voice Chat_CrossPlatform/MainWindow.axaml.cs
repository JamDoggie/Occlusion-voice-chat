using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Lidgren.Network;
using Occlusion.NetworkingShared;
using Occlusion_voice_chat.Networking;
using Occlusion_voice_chat.util.json_structs;
using OcclusionShared.NetworkingShared.Packets;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class MainWindow : Window
    {
        public static MainWindow mainWindow;

        #region Controls

        public TextBox NameTextbox;
        public TextBox IpTextbox;
        public TextBox PortTextbox;
        public TextBox CodeTextBox;
        public Button ConnectButton;
        public Grid ErrorMessageGroup;
        public Grid GenericMessageGroup;
        public TextBlock GenericErrorMessage;
        public WrapPanel ServerIconsPanel;
        public Button AddServerButton;
        public Button RemoveServerButton;
        #endregion

        private ServerSelection? _currentServerSelection = null;

        public ServerSelection? CurrentServerSelection
        {
            get
            {
                return _currentServerSelection;
            }

            set
            {
                if (!App.Client.IsConnected())
                {
                    _currentServerSelection = value;
                }
            }
        }

        private bool _settingsActive = false;

        public bool SettingsActive
        {
            get
            {
                if (App.Client.IsConnected())
                    return false;
                
                return _settingsActive;
            }

            set
            {
                if (!App.Client.IsConnected())
                {
                    _settingsActive = value;

                    NameTextbox.IsEnabled = value;
                    IpTextbox.IsEnabled = value;
                    PortTextbox.IsEnabled = value;
                    CodeTextBox.IsEnabled = value;
                    ConnectButton.IsEnabled = value;
                }
                else
                {
                    NameTextbox.IsEnabled = false;
                    IpTextbox.IsEnabled = false;
                    PortTextbox.IsEnabled = false;
                    CodeTextBox.IsEnabled = false;
                    ConnectButton.IsEnabled = false;
                }
                
            }
        }
        
        public MainWindow()
        {
            mainWindow = this;

            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            NameTextbox = this.FindControl<TextBox>("NameTextbox");
            IpTextbox = this.FindControl<TextBox>("IpTextbox");
            PortTextbox = this.FindControl<TextBox>("PortTextbox");
            CodeTextBox = this.FindControl<TextBox>("CodeTextBox");
            ConnectButton = this.FindControl<Button>("ConnectButton");
            ErrorMessageGroup = this.FindControl<Grid>("ErrorMessageGroup");
            GenericMessageGroup = this.FindControl<Grid>("GenericMessageGroup");
            GenericErrorMessage = this.FindControl<TextBlock>("GenericErrorMessage");
            ServerIconsPanel = this.FindControl<WrapPanel>("ServerIconsPanel");
            AddServerButton = this.FindControl<Button>("AddServerButton");
            RemoveServerButton = this.FindControl<Button>("RemoveServerButton");
            
            AddServerButton.Click += AddServerButtonOnClick;
            RemoveServerButton.Click += RemoveServerButtonOnClick;
            
            NameTextbox.PropertyChanged += NameTextboxOnPropertyChanged;
            IpTextbox.PropertyChanged += IpTextboxOnPropertyChanged;
            PortTextbox.PropertyChanged += PortTextboxOnPropertyChanged;
            
                App.Client.PacketRecievedEvent += Client_PacketRecievedEvent;

            ConnectButton.Click += Connect_Click;
            this.FindControl<Button>("ErrorMessageOk").Click += Error_Message_Ok_Click;
            this.FindControl<Button>("GenericMessageOk").Click += Generic_Error_Message_Ok;

            foreach (KeyValuePair<string, Occlusion_voice_chat.util.json_structs.ServerSelection> pair in App.Options
                .Obj.ServerSelections)
            {
                ShowServerListing(pair.Key);
            }

            SettingsActive = false;
        }

        private void PortTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;

                    if (CurrentServerSelection != null)
                    {
                        if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName,
                            out selection))
                        {
                            if (int.TryParse(PortTextbox.Text, out int port))
                            {
                                selection.Port = port;
                                App.Options.Update();
                            }
                        }
                    }
                }
            }
        }

        private void IpTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;

                    if (CurrentServerSelection != null)
                    {
                        if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName,
                            out selection))
                        {
                            selection.IP = IpTextbox.Text;
                            App.Options.Update();
                        }
                    }
                }
            }
        }

        private void NameTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;
                
                    if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName, out selection) && 
                        !App.Options.Obj.ServerSelections.TryGetValue(NameTextbox.Text, out _))
                    {
                        App.Options.Obj.ServerSelections.Remove(CurrentServerSelection.BackingName);
                        App.Options.Obj.ServerSelections[NameTextbox.Text] = selection;

                        CurrentServerSelection.BackingName = NameTextbox.Text;
                        CurrentServerSelection.NameText.Text = NameTextbox.Text;
                        
                        App.Options.Update();
                    }
                }
            }
            
        }

        private void RemoveServerButtonOnClick(object? sender, RoutedEventArgs e)
        {
            if (CurrentServerSelection != null)
            {
                ServerIconsPanel.Children.Remove(CurrentServerSelection);

                App.Options.Obj.ServerSelections.Remove(CurrentServerSelection.BackingName);
                App.Options.Update();

                SettingsActive = false;
            }
        }

        private void AddServerButtonOnClick(object? sender, RoutedEventArgs e)
        {
            AddNewServerListing(GetNextAvailableServerName());
        }

        public void PopulateServerSettings()
        {
            if (CurrentServerSelection != null)
            {
                SettingsActive = true;

                foreach (KeyValuePair<string, Occlusion_voice_chat.util.json_structs.ServerSelection> pair in App
                    .Options.Obj.ServerSelections)
                {
                    if (pair.Key == CurrentServerSelection.BackingName)
                    {
                        NameTextbox.Text = pair.Key;
                        IpTextbox.Text = pair.Value.IP;
                        PortTextbox.Text = pair.Value.Port.ToString();
                        CodeTextBox.Text = string.Empty;
                    }
                }
            }
            else
            {
                SettingsActive = false;
                NameTextbox.Text = string.Empty;
                IpTextbox.Text = string.Empty;
                PortTextbox.Text = string.Empty;
                CodeTextBox.Text = string.Empty;
            }
        }
        
        public void AddNewServerListing(string name)
        {
            App.Options.Obj.ServerSelections[name] = new Occlusion_voice_chat.util.json_structs.ServerSelection();
            App.Options.Update();

            ShowServerListing(name);
        }

        public void ShowServerListing(string name)
        {
            ServerSelection serverSelection = new ServerSelection();
            serverSelection.BackingName = name;
            serverSelection.NameText.Text = name;
            serverSelection.Margin = new Thickness(10, 10, 10, 10);
            
            ServerIconsPanel.Children.Add(serverSelection);
        }
        
        public string GetNextAvailableServerName()
        {
            int serverIter = 1;

            if (!App.Options.Obj.ServerSelections.TryGetValue("New Server", out _))
                return "New Server";

            while (App.Options.Obj.ServerSelections.TryGetValue("New Server " + serverIter, out _))
            {
                serverIter++;
            }

            return "New Server " + serverIter;
        }
        
        private void Client_PacketRecievedEvent(NetIncomingMessage message, IPacket packet, Client client)
        {
            if (packet is ServerValidationRejected)
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    ErrorMessageGroup.IsVisible = true;
                });
            }
        }

        public void ShowErrorMessage(string message)
        {
            GenericMessageGroup.IsVisible = true;

            GenericErrorMessage.Text = message;
        }

        public void Connect_Click(object? sender, RoutedEventArgs e)
        {
            bool portValid = int.TryParse(PortTextbox.Text, out int serverport);
            bool codeValid = int.TryParse(CodeTextBox.Text, out int code);

            if (portValid && codeValid)
                App.Connect(IpTextbox.Text, serverport, code);
        }

        public void Error_Message_Ok_Click(object? sender, RoutedEventArgs e)
        {
            if (ErrorMessageGroup.IsVisible)
                ErrorMessageGroup.IsVisible = false;
        }

        public void Generic_Error_Message_Ok(object? sender, RoutedEventArgs e)
        {
            if (GenericMessageGroup.IsVisible)
                GenericMessageGroup.IsVisible = false;
        }
    }
}
