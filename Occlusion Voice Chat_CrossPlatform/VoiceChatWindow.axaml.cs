#nullable disable

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using Occlusion_voice_chat.Mojang;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using SdlSharp.Sound;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class VoiceChatWindow : Window
    {
        #region Controls
        public ProgressBar MicDecibalMeter;

        public Slider InputVolumeSlider;
            
        public ProgressBar SettingsMicMeter;

        public Grid AudioSettingsGroup;

        public TextBlock InputVolumeTextbox;

        public TextBlock OutputVolumeTextbox;

        public Slider OutputVolumeSlider;

        public ComboBox InputDeviceDropdown;

        public ComboBox OutputDeviceDropdown;

        public WrapPanel PlayerIconsPanel;

        public TextBlock AudioSettingsHeader;
        public ProgressBar SpeakerDecibalMeter;
        public ProgressBar VoiceActivityBar;
        public UserPanel UserControlPanel;

        public Button SettingsButton;

        public Canvas UserPanelCanvas;

        public ProgressBar SettingsSpeakerMeter;
        #endregion

        public bool IsOpen { get; set; } = false;
        public bool UserPanelOpen { get; set; } = false;

        public bool AudioSettingsOpen { get; set; } = false;

        public VoiceChatWindowModel ViewModel { get; set; } = new VoiceChatWindowModel();

        private List<PlayerIcon> _playerIcons = new List<PlayerIcon>();

        public VoiceChatWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            MicDecibalMeter = this.FindControl<ProgressBar>("MicDecibalMeter");
            InputVolumeSlider = this.FindControl<Slider>("InputVolumeSlider");
            SettingsMicMeter = this.FindControl<ProgressBar>("SettingsMicMeter");
            AudioSettingsGroup = this.FindControl<Grid>("AudioSettingsGroup");
            InputVolumeTextbox = this.FindControl<TextBlock>("InputVolumeTextbox");
            OutputVolumeTextbox = this.FindControl<TextBlock>("OutputVolumeTextbox");
            OutputVolumeSlider = this.FindControl<Slider>("OutputVolumeSlider");
            InputDeviceDropdown = this.FindControl<ComboBox>("InputDeviceDropdown");
            OutputDeviceDropdown = this.FindControl<ComboBox>("OutputDeviceDropdown");
            PlayerIconsPanel = this.FindControl<WrapPanel>("PlayerIconsPanel");
            AudioSettingsHeader = this.FindControl<TextBlock>("AudioSettingsHeader");
            SpeakerDecibalMeter = this.FindControl<ProgressBar>("SpeakerDecibalMeter");
            VoiceActivityBar = this.FindControl<ProgressBar>("VoiceActivityBar");
            UserControlPanel = this.FindControl<UserPanel>("UserControlPanel");
            SettingsButton = this.FindControl<Button>("SettingsButton");
            UserPanelCanvas = this.FindControl<Canvas>("UserPanelCanvas");
            SettingsSpeakerMeter = this.FindControl<ProgressBar>("SettingsSpeakerMeter");


            Closed += Window_Closed;
            Closing += OnClosing;
            PointerPressed += Window_MouseDown;



            AudioSettingsGroup.IsVisible = true;

            // Volume controls
            InputVolumeSlider.Value = App.InputVolume;
            InputVolumeTextbox.Text = (int)(InputVolumeSlider.Value * 100) + "%";

            OutputVolumeSlider.Value = App.OutputVolume;
            OutputVolumeTextbox.Text = (int)(OutputVolumeSlider.Value * 100) + "%";

            // Events cuz Avalonia won't let me bind them in XAML no matter what i do.
            this.FindControl<MenuItem>("DisconnectMenuButton").Click += Menu_Disconnect_Click;

            this.FindControl<Button>("MuteButton").Click += Mute_Click_1;
            this.FindControl<Button>("DeafenButton").Click += Deafen_Click;

            this.FindControl<Button>("InfoButton").Click  += InfoButton_Click;
            this.FindControl<Button>("InfoButton").PointerMoved += InfoButton_MouseMove;

            AudioSettingsGroup.PropertyChanged += AudioSettingsGroup_PropertyChanged;

            SettingsButton.Click += Settings_Click;
            SettingsButton.PointerEnter += SettingsButton_PointerEnter;
            SettingsButton.PointerLeave += SettingsButton_PointerLeave;

            Opened += VoiceChatWindow_Opened;
            Activated += VoiceChatWindow_Activated;
            InputDeviceDropdown.SelectionChanged += InputDeviceDropdown_DropDownClosed;
            OutputDeviceDropdown.SelectionChanged += OutputDeviceDropdown_DropDownClosed;

            InputVolumeSlider.PropertyChanged += InputVolume_ValueChanged;

            VoiceActivityBar.PointerPressed += VoiceActivityBar_MouseDown;
            VoiceActivityBar.PointerReleased += VoiceActivityBar_MouseUp;
            VoiceActivityBar.PointerMoved += VoiceActivityBar_MouseMove;
            VoiceActivityBar.PointerLeave += VoiceActivityBar_MouseLeave;

            OutputVolumeSlider.PropertyChanged += OutputVolume_ValueChanged;

            this.FindControl<Button>("SettingsOkButton").Click += Settings_Ok_Click;

            OpenAudioSettings();
        }

        public bool ForceClose { get; set; } = false;

        public async void OnClosing(object sender, CancelEventArgs e)
        {
            if (!ForceClose)
            {
                var msBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams
                    {
                        ButtonDefinitions = ButtonEnum.OkCancel,
                        ContentTitle = "Warning",
                        ContentMessage = "Closing this will disconnect you from the server.",
                        Icon = MessageBox.Avalonia.Enums.Icon.Warning,
                        Style = Style.Windows,

                    });

                e.Cancel = true;
                var result = await msBoxStandardWindow.ShowDialog(this);

                if (result == ButtonResult.Ok)
                {
                    App.Client.DisconnectClient("", false);
                }  
            }
        }

        private void AudioSettingsGroup_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            
            if (e.Property == Grid.OpacityProperty && e.Priority == BindingPriority.Animation)
            {
                if ((double)e.OldValue != 0 && (double)e.NewValue == 0)
                {
                    AudioSettingsGroup.IsVisible = false;
                }

                if ((double)e.OldValue == 0 && (double)e.NewValue != 0)
                {
                    AudioSettingsGroup.IsVisible = true;
                }
            }
            
        }

        private void VoiceChatWindow_Activated(object sender, EventArgs e)
        {
            IsOpen = true;
        }

        private void VoiceChatWindow_Opened(object sender, EventArgs e)
        {
            IsOpen = true;
            // Window load stuff
            MainWindow.mainWindow.ConnectButton.IsEnabled = false;
            VoiceActivityBar.Value = Math.Clamp(App.Options.Obj.VoiceActivity, 0, 3000);

            InputVolumeSlider.Value = App.Options.Obj.InputVolume;
            OutputVolumeSlider.Value = App.Options.Obj.OutputVolume;
        }

        private void SettingsButton_PointerLeave(object sender, PointerEventArgs e)
        {
            RotateTransform transform = (RotateTransform)this.FindControl<Image>("SettingsImage").RenderTransform;
            transform.Angle = 0;
        }

        private void SettingsButton_PointerEnter(object sender, PointerEventArgs e)
        {
            RotateTransform transform = (RotateTransform)this.FindControl<Image>("SettingsImage").RenderTransform;
            transform.Angle = -30;
        }

        public void OpenAudioSettings()
        {
            AudioSettingsOpen = true;
            AudioSettingsGroup.Opacity = 1;

            
                // Populate combo boxes
                // Input Device
                RetrieveInputDevices();

                // Output Device
                RetrieveOutputDevices();
            
        }

        public void AddPlayer(string uuid, int id)
        {
            PlayerIcon playerIcon = new PlayerIcon();
            PlayerIconsPanel.Children.Add(playerIcon);
            _playerIcons.Add(playerIcon);

            string skinURL = PlayerCache.GetCachedPlayerSkinURL(uuid);
            string playerName = PlayerCache.GetCachedPlayerUsername(uuid);

            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();

            WebClient webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(skinURL);
            MemoryStream stream = new MemoryStream(imageBytes);

            Bitmap image = new Bitmap(stream);
            
            playerIcon.PlayerIconImg.Stretch = Stretch.Fill;
            playerIcon.PlayerIconImg.Source = image;

            playerIcon.PlayerName.Text = playerName;

            playerIcon.PlayerID = id;
            playerIcon.UUID = uuid;

            playerIcon.InitImages();
        }
        
        public void RetrieveInputDevices()
        {
            
            List<string> items = new List<string>();

            items.Add("Default");
            
            foreach (string s in Audio.CaptureDevices)
            {
                items.Add(s.Substring(0, s.Length));
            }

            InputDeviceDropdown.Items = items;
            InputDeviceDropdown.SelectedIndex = 0;
            
        }

        public void RetrieveOutputDevices()
        {
            
            List<string> items = new List<string>();

            items.Add("Default");
            foreach (string s in Audio.NonCaptureDevices)
            {
                items.Add(s.Substring(0, s.Length));
            }

            OutputDeviceDropdown.Items = items;
            OutputDeviceDropdown.SelectedIndex = 0;
            
        }


        public PlayerIcon GetPlayerIconByUUID(string uuid)
        {
            foreach (PlayerIcon icon in _playerIcons)
            {
                if (icon.UUID == uuid)
                {
                    return icon;
                }
            }

            return null;
        }

        public void RemovePlayerIcon(PlayerIcon icon)
        {
            _playerIcons.Remove(icon);
            PlayerIconsPanel.Children.Remove(icon);

            Console.WriteLine("user removed");
        }

        public void CloseAudioSettings()
        {
            AudioSettingsOpen = false;

            AudioSettingsGroup.Opacity = 0;
        }

        public void InputVolume_ValueChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Slider.ValueProperty)
            {
                InputVolumeTextbox.Text = (int)(InputVolumeSlider.Value * 100) + "%";
                App.InputVolume = (float)InputVolumeSlider.Value;
            }
        }

        public void OutputVolume_ValueChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Slider.ValueProperty)
            {
                OutputVolumeTextbox.Text = (int)(OutputVolumeSlider.Value * 100) + "%";
                App.OutputVolume = (float)OutputVolumeSlider.Value;
            }

        }

        public void Settings_Ok_Click(object sender, RoutedEventArgs e)
        {
            App.Options.Obj.InputVolume = (float)InputVolumeSlider.Value;
            App.Options.Obj.OutputVolume = (float)OutputVolumeSlider.Value;

            App.Options.Update();

            CloseAudioSettings();
        }

        /*private void SettingsCloseAnim_Completed(object sender, EventArgs e)
        {
            AudioSettingsGroup.IsVisible = false;
            AudioSettingsHeader.Text = "Audio Settings";
        }*/

        public void InputDeviceDropdown_DropDownClosed(object sender, SelectionChangedEventArgs e)
        {
            App.Options.Obj.InputDevice = (string)InputDeviceDropdown.SelectedItem;
            App.Options.Update();

            App.NewInputDevice = App.Options.Obj.InputDevice;
        }

        public void OutputDeviceDropdown_DropDownClosed(object sender, SelectionChangedEventArgs e)
        {
                App.Options.Obj.OutputDevice = (string)OutputDeviceDropdown.SelectedItem;
                App.Options.Update();

                App.NewOutputDevice = App.Options.Obj.OutputDevice;
        }

        public void Window_Closed(object sender, EventArgs e)
        {
            IsOpen = false;
            MainWindow.mainWindow.ConnectButton.IsEnabled = true;
        }

        // Settings Cog Mouse Click
        public void Settings_Click(object sender, RoutedEventArgs e)
        {
            OpenAudioSettings();
        }

        public void Mute_Click_1(object sender, RoutedEventArgs e)
        {
            App.MicMuted = !App.MicMuted;

            switch (App.MicMuted)
            {
                case true:
                    ViewModel.CurrentMicIcon = "/resources/occlusion_mic_icon_muted.png";
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
                    break;

                case false:
                    ViewModel.CurrentMicIcon = "/resources/occlusion_mic_icon.png";
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));

                    if (App.Deafened)
                    {
                        App.Deafened = false;
                        ViewModel.CurrentDeafenIcon = "/resources/speaker_unmuted.png";
                        SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));
                    }
                    break;
            }
        }


        public void Window_MouseDown(object sender, PointerPressedEventArgs e)
        {
            if (UserPanelOpen)
            {
                if (!UserControlPanel.IsPointerOver)
                {
                    UserControlPanel.Opacity = 0;

                    UserPanelOpen = false;
                }
            }
        }

        public void Menu_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            App.Client.DisconnectClient("", false);
            
        }

        public void Deafen_Click(object sender, RoutedEventArgs e)
        {
            App.Deafened = !App.Deafened;

            switch (App.Deafened)
            {
                case true:
                    ViewModel.CurrentDeafenIcon = "/resources/speaker_muted.png";
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
                    break;

                case false:
                    ViewModel.CurrentDeafenIcon = "/resources/speaker_unmuted.png";
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));
                    break;
            }

            if (App.Deafened)
            {
                App.MicMuted = true;
                ViewModel.CurrentMicIcon = "/resources/occlusion_mic_icon_muted.png";
                MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
            }

        }

        private bool isVoiceMouseDown = false;

        public void VoiceActivityBar_MouseDown(object sender, PointerPressedEventArgs e)
        {
            var relativePoint = e.GetPosition(VoiceActivityBar);
            VoiceActivityBar.Value = Math.Clamp(relativePoint.X / VoiceActivityBar.Width * 3000, 0, 3000);

            isVoiceMouseDown = true;
        }

        public void VoiceActivityBar_MouseUp(object sender, PointerReleasedEventArgs e)
        {
            isVoiceMouseDown = false;

            // Update the voice activity value now so we aren't constantly doing I/O for no reason while dragging the bar.
            App.Options.Obj.VoiceActivity = (float)VoiceActivityBar.Value;
        }

        public void VoiceActivityBar_MouseMove(object sender, PointerEventArgs e)
        {
            if (isVoiceMouseDown)
            {
                var relativePoint = e.GetPosition(VoiceActivityBar);
                VoiceActivityBar.Value = Math.Clamp(relativePoint.X / VoiceActivityBar.Width * 3000, 0, 3000);

                App.VoiceActivity = (float)VoiceActivityBar.Value;
            }
        }

        public void VoiceActivityBar_MouseLeave(object sender, PointerEventArgs e)
        {
            isVoiceMouseDown = false;
        }

        public void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void InfoButton_MouseMove(object sender, RoutedEventArgs e)
        {

        }
    }
}
