using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using Occlusion_voice_chat.Mojang;
using Occlusion_Voice_Chat_CrossPlatform.audio;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using SdlSharp.Sound;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls.messagebox;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public partial class VoiceChatControl : UserControl
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

        public Border MuteIconSlash;

        public Border DeafenIconSlash;

        public SettingsPage SettingsPage;

        public Grid AutoDisconnectScreen;

        public TextBlock AutoDisconnectText;
        #endregion

        public bool IsOpen { get; set; } = false;
        public bool UserPanelOpen { get; set; } = false;

        public bool AudioSettingsOpen { get; set; } = false;

        public VoiceChatWindowModel ViewModel { get; set; } = new VoiceChatWindowModel();

        private List<PlayerIcon> _playerIcons = new List<PlayerIcon>();

        public int AutoDisconnectSeconds { get; set; } = 0;

        public VoiceChatControl()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        public void Dispose()
        {
            SettingsPage.PushTalkBind.HotkeyPressed -= PushTalkBind_HotkeyPressed;
            SettingsPage.PushTalkBind.HotkeyReleased -= PushTalkBind_HotkeyReleased;

            SettingsPage.PushMuteBind.HotkeyPressed -= PushMuteBind_HotkeyPressed;
            SettingsPage.PushMuteBind.HotkeyReleased -= PushMuteBind_HotkeyReleased;

            SettingsPage.PushDeafenBind.HotkeyPressed -= PushDeafenBind_HotkeyPressed;
            SettingsPage.PushDeafenBind.HotkeyReleased -= PushDeafenBind_HotkeyReleased;

            SettingsPage.ToggleMuteBind.HotkeyPressed -= ToggleMuteBind_HotkeyPressed;

            SettingsPage.ToggleDeafenBind.HotkeyPressed -= ToggleDeafenBind_HotkeyPressed;
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            SettingsPage = this.FindControl<SettingsPage>("SettingsPage");
            MicDecibalMeter = this.FindControl<ProgressBar>("MicDecibalMeter");
            InputVolumeSlider = SettingsPage.FindControl<Slider>("InputVolumeSlider");
            SettingsMicMeter = SettingsPage.FindControl<ProgressBar>("SettingsMicMeter");

            AudioSettingsGroup = SettingsPage.FindControl<Grid>("AudioSettingsGroup");
            InputVolumeTextbox = SettingsPage.FindControl<TextBlock>("InputVolumeTextbox");
            OutputVolumeTextbox = SettingsPage.FindControl<TextBlock>("OutputVolumeTextbox");
            OutputVolumeSlider = SettingsPage.FindControl<Slider>("OutputVolumeSlider");
            InputDeviceDropdown = SettingsPage.FindControl<ComboBox>("InputDeviceDropdown");
            OutputDeviceDropdown = SettingsPage.FindControl<ComboBox>("OutputDeviceDropdown");
            PlayerIconsPanel = this.FindControl<WrapPanel>("PlayerIconsPanel");
            AudioSettingsHeader = SettingsPage.FindControl<TextBlock>("AudioSettingsHeader");
            SpeakerDecibalMeter = this.FindControl<ProgressBar>("SpeakerDecibalMeter");
            VoiceActivityBar = SettingsPage.FindControl<ProgressBar>("VoiceActivityBar");
            UserControlPanel = this.FindControl<UserPanel>("UserControlPanel");
            SettingsButton = this.FindControl<Button>("SettingsButton");
            UserPanelCanvas = this.FindControl<Canvas>("UserPanelCanvas");
            SettingsSpeakerMeter = SettingsPage.FindControl<ProgressBar>("SettingsSpeakerMeter");
            MuteIconSlash = this.FindControl<Border>("MuteIconSlash");
            DeafenIconSlash = this.FindControl<Border>("DeafenIconSlash");
            AutoDisconnectScreen = this.FindControl<Grid>("AutoDisconnectScreen");
            AutoDisconnectText = this.FindControl<TextBlock>("AutoDisconnectText");

            PointerPressed += Window_MouseDown;
            this.FindControl<Button>("LeaveButton").Click += LeaveButton_Click;


            PropertyChanged += VoiceChatControl_PropertyChanged;

            SettingsPage.IsVisible = true;

            // Volume controls
            InputVolumeSlider.Value = App.InputVolume;
            InputVolumeTextbox.Text = (int)(InputVolumeSlider.Value * 100) + "%";

            OutputVolumeSlider.Value = App.OutputVolume;
            OutputVolumeTextbox.Text = (int)(OutputVolumeSlider.Value * 100) + "%";

            // Events cuz Avalonia won't let me bind them in XAML no matter what i do.

            this.FindControl<Button>("MuteButton").Click += Mute_Click_1;
            this.FindControl<Button>("DeafenButton").Click += Deafen_Click;

            this.FindControl<Button>("InfoButton").Click += InfoButton_Click;
            this.FindControl<Button>("InfoButton").PointerMoved += InfoButton_MouseMove;

            SettingsPage.PropertyChanged += AudioSettingsGroup_PropertyChanged;

            SettingsButton.Click += Settings_Click;
            SettingsButton.PointerEnter += SettingsButton_PointerEnter;
            SettingsButton.PointerLeave += SettingsButton_PointerLeave;

            // TODO
            //Activated += VoiceChatWindow_Activated;
            InputDeviceDropdown.SelectionChanged += InputDeviceDropdown_DropDownClosed;
            OutputDeviceDropdown.SelectionChanged += OutputDeviceDropdown_DropDownClosed;

            InputVolumeSlider.PropertyChanged += InputVolume_ValueChanged;

            VoiceActivityBar.PointerPressed += VoiceActivityBar_MouseDown;
            VoiceActivityBar.PointerReleased += VoiceActivityBar_MouseUp;
            VoiceActivityBar.PointerMoved += VoiceActivityBar_MouseMove;
            VoiceActivityBar.PointerLeave += VoiceActivityBar_MouseLeave;

            OutputVolumeSlider.PropertyChanged += OutputVolume_ValueChanged;

            SettingsPage.FindControl<Button>("SettingsOkButton").Click += Settings_Ok_Click;


            // Key binds
            SettingsPage.PushTalkBind.HotkeyPressed += PushTalkBind_HotkeyPressed;
            SettingsPage.PushTalkBind.HotkeyReleased += PushTalkBind_HotkeyReleased;

            SettingsPage.PushMuteBind.HotkeyPressed += PushMuteBind_HotkeyPressed;
            SettingsPage.PushMuteBind.HotkeyReleased += PushMuteBind_HotkeyReleased;

            SettingsPage.PushDeafenBind.HotkeyPressed += PushDeafenBind_HotkeyPressed;
            SettingsPage.PushDeafenBind.HotkeyReleased += PushDeafenBind_HotkeyReleased;

            SettingsPage.ToggleMuteBind.HotkeyPressed += ToggleMuteBind_HotkeyPressed;

            SettingsPage.ToggleDeafenBind.HotkeyPressed += ToggleDeafenBind_HotkeyPressed;


            if (SettingsPage.AudioSettingsGroup.RenderTransform is TranslateTransform gridTransform)
                gridTransform.Y = 1000;

            OpenAudioSettings();



            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void VoiceChatControl_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Grid.OpacityProperty && e.Priority == BindingPriority.Animation)
            {
                
                if ((double)e.OldValue != 0 && (double)e.NewValue == 0)
                {
                    IsVisible = false;
                }

                if ((double)e.OldValue == 0 && (double)e.NewValue != 0)
                {
                    IsVisible = true;
                }
                
            }
        }

        private async void LeaveButton_Click(object? sender, RoutedEventArgs e)
        {
            OcclusionMessageBox msgBox = OcclusionMessageBox.GetMessageBox(MessageBoxType.YES_CANCEL, "Warning", "Really disconnect from the server?");

            MessageBoxResult result = await msgBox.Show(MainWindow.mainWindow);
            if (result.Result != null && result.Result.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                App.Client.DisconnectClient("", false);
                Close();
            }
        }

        private void ToggleDeafenBind_HotkeyPressed()
        {
            SetDeafened(!App.Deafened);

            if (App.Deafened)
            {
                new OggOpusSoundEffect(Sounds.DeafenSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
            }
        }

        private void ToggleMuteBind_HotkeyPressed()
        {
            bool wasDeaf = App.Deafened;
            SetMuted(!App.MicMuted);

            if (App.MicMuted)
            {
                new OggOpusSoundEffect(Sounds.MicMuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                if (wasDeaf && !App.Deafened)
                    new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
                else
                    new OggOpusSoundEffect(Sounds.MicUnmuteSound, 0.7f, filePreloaded: true).Play();
            }
        }


        // Push to Deafen
        private void PushDeafenBind_HotkeyPressed()
        {
            App.PushToDeafenHeld = true;

            DeafenIconSlash.Width = 45;

            if (App.PushToDeafenHeld)
            {
                new OggOpusSoundEffect(Sounds.DeafenSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
            }
        }

        private void PushDeafenBind_HotkeyReleased()
        {
            App.PushToDeafenHeld = false;

            if (!App.Deafened)
            {
                DeafenIconSlash.Width = 0;
            }

            if (App.PushToDeafenHeld)
            {
                new OggOpusSoundEffect(Sounds.DeafenSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
            }
        }


        // Push to Talk
        private void PushTalkBind_HotkeyPressed()
        {
            App.PushToTalkHeld = true;

            if (App.PushToTalkHeld)
            {
                new OggOpusSoundEffect(Sounds.PushUnmuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.PushMuteSound, 0.7f, filePreloaded: true).Play();
            }
        }

        private void PushTalkBind_HotkeyReleased()
        {
            App.PushToTalkHeld = false;

            if (App.PushToTalkHeld)
            {
                new OggOpusSoundEffect(Sounds.PushUnmuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.PushMuteSound, 0.7f, filePreloaded: true).Play();
            }
        }

        // Push to Mute
        private void PushMuteBind_HotkeyPressed()
        {
            App.PushToMuteHeld = true;

            MuteIconSlash.Width = 45;

            if (App.PushToMuteHeld)
            {
                new OggOpusSoundEffect(Sounds.MicMuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.MicUnmuteSound, 0.7f, filePreloaded: true).Play();
            }
        }

        private void PushMuteBind_HotkeyReleased()
        {
            App.PushToMuteHeld = false;

            if (App.PushToMuteHeld)
            {
                new OggOpusSoundEffect(Sounds.MicMuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.MicUnmuteSound, 0.7f, filePreloaded: true).Play();
            }

            if (!App.MicMuted)
            {
                MuteIconSlash.Width = 0;
            }
        }



        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (AutoDisconnectSeconds > 0)
            {
                AutoDisconnectSeconds--;

                int minutes = AutoDisconnectSeconds / 60;
                int seconds = AutoDisconnectSeconds - (minutes * 60);

                string minString = $"{minutes}";
                if (minutes < 10)
                    minString = $"0{minutes}";

                string secString = $"{seconds}";
                if (seconds < 10)
                    secString = $"0{seconds}";

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    AutoDisconnectText.Text = $"You will be auto disconnected in {minString}:{secString}";
                });

            }
        }

        public bool ForceClose { get; set; } = false;

        private void AudioSettingsGroup_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (e.Property == Grid.OpacityProperty && e.Priority == BindingPriority.Animation)
            {
                if (this.FindControl<Grid>("BottomBar").RenderTransform is TranslateTransform translate)
                {
                    if ((double)e.OldValue != 0 && (double)e.NewValue == 0)
                    {
                        SettingsPage.IsVisible = false;
                        AudioSettingsHeader.Text = "Settings";
                        translate.Y = 0;
                    }

                    if ((double)e.OldValue == 0 && (double)e.NewValue != 0)
                    {
                        SettingsPage.IsVisible = true;
                        translate.Y = 100;
                    }
                }
            }
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

        public void CloseAudioSettings()
        {
            AudioSettingsOpen = false;
            SettingsPage.Opacity = 0;
            if (SettingsPage.AudioSettingsGroup.RenderTransform is TranslateTransform gridTransform)
                gridTransform.Y = 1000;

            App.HRTFPreview.Muted = true;
            SettingsPage.HRTFIconSlash.Width = 35;
        }

        public void OpenAudioSettings()
        {
            AudioSettingsOpen = true;
            SettingsPage.Opacity = 1;


            // Populate combo boxes
            // Input Device
            RetrieveInputDevices();

            // Output Device
            RetrieveOutputDevices();


            if (SettingsPage.AudioSettingsGroup.RenderTransform is TranslateTransform gridTransform)
                gridTransform.Y = 0;
        }

        public async void AddPlayer(string uuid, int id)
        {
            PlayerIcon playerIcon = new PlayerIcon();
            PlayerIconsPanel.Children.Add(playerIcon);
            _playerIcons.Add(playerIcon);

            string skinURL = await PlayerCache.GetCachedPlayerSkinURL(uuid);
            string playerName = await PlayerCache.GetCachedPlayerUsername(uuid);

            if (skinURL == null)
                skinURL = "http://assets.mojang.com/SkinTemplates/4px_reference.png";

            if (playerName == null)
                playerName = "Unknown Player";


            Stream stream = await HttpGetStream(skinURL);

            Bitmap image = new Bitmap(stream);

            playerIcon.PlayerIconImg.Stretch = Stretch.Fill;
            playerIcon.PlayerIconImg.Source = image;

            playerIcon.PlayerName.Text = playerName;

            playerIcon.PlayerID = id;
            playerIcon.UUID = uuid;

            playerIcon.InitImages();
        }

        private static async Task<Stream> HttpGetStream(string uri)
        {
            try
            {
                HttpResponseMessage response = await App.HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();
            }
            catch
            {
                return Stream.Null;
            }
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

            foreach (string s in items)
            {
                if (s == App.Options.Obj.InputDevice)
                {
                    InputDeviceDropdown.SelectedItem = s;
                }
            }

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

            foreach (string s in items)
            {
                if (s == App.Options.Obj.OutputDevice)
                {
                    OutputDeviceDropdown.SelectedItem = s;
                }
            }
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

            App.Options.Save();

            CloseAudioSettings();
        }

        /*private void SettingsCloseAnim_Completed(object sender, EventArgs e)
        {
            
        }*/

        public void InputDeviceDropdown_DropDownClosed(object sender, SelectionChangedEventArgs e)
        {
            App.Options.Obj.InputDevice = (string)InputDeviceDropdown.SelectedItem;
            App.Options.Save();

            App.NewInputDevice = App.Options.Obj.InputDevice;
        }

        public void OutputDeviceDropdown_DropDownClosed(object sender, SelectionChangedEventArgs e)
        {
            if (OutputDeviceDropdown.SelectedItem != null)
            {
                App.Options.Obj.OutputDevice = (string)OutputDeviceDropdown.SelectedItem;
                App.Options.Save();

                App.NewOutputDevice = App.Options.Obj.OutputDevice;
            }
        }

        public void Close()
        {
            IsOpen = false;
            Opacity = 0;
            MainWindow.mainWindow.ConnectButton.IsEnabled = true;
        }

        public void Open()
        {
            IsVisible = true;
            Opacity = 1;
            IsOpen = true;
            // Window load stuff
            MainWindow.mainWindow.ConnectButton.IsEnabled = false;
            VoiceActivityBar.Value = Math.Clamp(App.Options.Obj.VoiceActivity, 0, 3000);

            InputVolumeSlider.Value = App.Options.Obj.InputVolume;
            OutputVolumeSlider.Value = App.Options.Obj.OutputVolume;

            SettingsPage.HRTFSwitch.IsChecked = App.Options.Obj.UseHRTF;

            // Clear stuff
            AutoDisconnectScreen.IsVisible = false;
            for(int i = _playerIcons.Count - 1; i >= 0; i--)
            {
                PlayerIcon icon = _playerIcons[i];
                RemovePlayerIcon(icon);
            }
        }

        // Settings Cog Mouse Click
        public void Settings_Click(object sender, RoutedEventArgs e)
        {
            OpenAudioSettings();
        }

        public void Mute_Click_1(object sender, RoutedEventArgs e)
        {
            bool wasDeaf = App.Deafened;
            SetMuted(!App.MicMuted);

            if (App.MicMuted)
            {
                new OggOpusSoundEffect(Sounds.MicMuteSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                if (wasDeaf && !App.Deafened)
                    new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
                else
                    new OggOpusSoundEffect(Sounds.MicUnmuteSound, 0.7f, filePreloaded: true).Play();
            }
        }

        public void Deafen_Click(object sender, RoutedEventArgs e)
        {
            SetDeafened(!App.Deafened);

            if (App.Deafened)
            {
                new OggOpusSoundEffect(Sounds.DeafenSound, 0.7f, filePreloaded: true).Play();
            }
            else
            {
                new OggOpusSoundEffect(Sounds.UndeafenSound, 0.7f, filePreloaded: true).Play();
            }
        }

        public void SetMuted(bool muted)
        {
            App.MicMuted = muted;

            switch (muted)
            {
                case true:
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));

                    MuteIconSlash.Width = 45;
                    this.FindControl<Image>("MicMutedImg").Opacity = 1;
                    break;

                case false:
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));

                    MuteIconSlash.Width = 0;

                    this.FindControl<Image>("MicMutedImg").Opacity = 0;

                    if (App.Deafened)
                    {
                        SetDeafened(false);
                    }
                    break;
            }
        }

        public void SetDeafened(bool deaf)
        {
            App.Deafened = deaf;

            switch (deaf)
            {
                case true:
                    ViewModel.CurrentDeafenIcon = "/resources/speaker_muted.png";
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
                    this.FindControl<Image>("DeafenedImg").Opacity = 1;
                    DeafenIconSlash.Width = 45;
                    SetMuted(true);
                    break;

                case false:
                    ViewModel.CurrentDeafenIcon = "/resources/speaker_unmuted.png";
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));
                    this.FindControl<Image>("DeafenedImg").Opacity = 0;
                    DeafenIconSlash.Width = 0;
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
