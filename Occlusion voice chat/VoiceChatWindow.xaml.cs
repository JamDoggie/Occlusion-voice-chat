#nullable enable

using SdlSharp.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SdlSharp;
using System.Threading;
using Occlusion_voice_chat.wpf.controls;
using Occlusion_voice_chat.Mojang;
using System.Reflection;

namespace Occlusion_voice_chat
{
    /// <summary>
    /// Interaction logic for VoiceChatWindow.xaml
    /// </summary>
    public partial class VoiceChatWindow : Window
    {
        public bool IsOpen { get; set; } = false;
        public bool UserPanelOpen { get; set; } = false;

        public bool AudioSettingsOpen { get; set; } = false;

        #region private fields
        private BitmapImage _micUnmutedImage = new BitmapImage();

        private BitmapImage _micMutedImage = new BitmapImage();

        private BitmapImage _speakerUnmutedImage = new BitmapImage();

        private BitmapImage _speakerMutedImage = new BitmapImage();
        #endregion

        private List<PlayerIcon> _playerIcons = new List<PlayerIcon>();

        public VoiceChatWindow()
        {
            InitializeComponent();
            IsOpen = true;
            
            AudioSettingsGroup.Visibility = Visibility.Visible;

            // Volume controls
            InputVolumeSlider.Value = App.InputVolume;
            InputVolumeTextbox.Text = (int)(InputVolumeSlider.Value * 100) + "%";

            OutputVolumeSlider.Value = App.OutputVolume;
            OutputVolumeTextbox.Text = (int)(OutputVolumeSlider.Value * 100) + "%";

            

            // Images
            _micUnmutedImage.BeginInit();
            _micUnmutedImage.UriSource = new Uri(@"pack://application:,,,/Occlusion%20voice%20chat;component/resources/occlusion_mic_icon.png", UriKind.Absolute);
            _micUnmutedImage.EndInit();

            _micMutedImage.BeginInit();
            _micMutedImage.UriSource = new Uri(@"pack://application:,,,/Occlusion%20voice%20chat;component/resources/occlusion_mic_icon_muted.png", UriKind.Absolute);
            _micMutedImage.EndInit();

            _speakerUnmutedImage.BeginInit();
            _speakerUnmutedImage.UriSource = new Uri(@"pack://application:,,,/Occlusion%20voice%20chat;component/resources/speaker_unmuted.png", UriKind.Absolute);
            _speakerUnmutedImage.EndInit();

            _speakerMutedImage.BeginInit();
            _speakerMutedImage.UriSource = new Uri(@"pack://application:,,,/Occlusion%20voice%20chat;component/resources/speaker_muted.png", UriKind.Absolute);
            _speakerMutedImage.EndInit();
        }

        public void OpenAudioSettings()
        {
            AudioSettingsOpen = true;
            AudioSettingsGroup.Visibility = Visibility.Visible;

            if (FindResource("AudioSettingsOpenAnim") is Storyboard openAnim)
            {
                openAnim.Begin(AudioSettingsGroup, true);
            }

            // Populate combo boxes
            // Input Device
            if (!(InputDeviceDropdown.ItemsSource is List<string>))
                InputDeviceDropdown.ItemsSource = new List<string>();
            else
                (InputDeviceDropdown.ItemsSource as List<string>).Clear();

            if (InputDeviceDropdown.ItemsSource is List<string> inputList)
            {
                inputList.Add("Default");

                foreach (string s in Audio.CaptureDevices)
                {
                    inputList.Add(s);
                }

            
                InputDeviceDropdown.SelectedIndex = inputList.IndexOf(App.Options.Obj.InputDevice);
            }


            // Output Device
            if (!(OutputDeviceDropdown.ItemsSource is List<string>))
                OutputDeviceDropdown.ItemsSource = new List<string>();
            else
                (OutputDeviceDropdown.ItemsSource as List<string>).Clear();

            if (OutputDeviceDropdown.ItemsSource is List<string> outputList)
            {
                outputList.Add("Default");

                foreach (string s in Audio.NonCaptureDevices)
                {
                    outputList.Add(s);
                }

            
                OutputDeviceDropdown.SelectedIndex = outputList.IndexOf(App.Options.Obj.OutputDevice);
            }
        }

        public void AddPlayer(string uuid, int id)
        {
            PlayerIcon playerIcon = new PlayerIcon();
            PlayerIconsPanel.Children.Add(playerIcon);
            _playerIcons.Add(playerIcon);

            string skinURL = PlayerCache.GetCachedPlayerSkinURL(uuid);
            string playerName = PlayerCache.GetCachedPlayerUsername(uuid);

            BitmapImage image = new BitmapImage();
            
            image.BeginInit();
            image.UriSource = new Uri(skinURL);
            image.EndInit();

            playerIcon.PlayerIconImg.Stretch = Stretch.Fill;
            playerIcon.PlayerIconImg.Source = image;

            playerIcon.PlayerName.Text = playerName;

            playerIcon.PlayerID = id;
            playerIcon.UUID = uuid;

            playerIcon.InitImages();
        }
        
        public PlayerIcon GetPlayerIconByUUID(string uuid)
        {
            foreach(PlayerIcon icon in _playerIcons)
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
            var storyBoard = (Storyboard)FindResource("AudioSettingsCloseAnim");

            if (storyBoard != null)
                storyBoard.Begin(AudioSettingsGroup, true);
        }

        private void InputVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                InputVolumeTextbox.Text = (int)(InputVolumeSlider.Value * 100) + "%";
                App.InputVolume = (float)InputVolumeSlider.Value;
            }
        }

        private void OutputVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                OutputVolumeTextbox.Text = (int)(OutputVolumeSlider.Value * 100) + "%";
                App.OutputVolume = (float)OutputVolumeSlider.Value;
            }
                
        }

        private void Settings_Ok_Click(object sender, RoutedEventArgs e)
        {
            App.Options.Obj.InputVolume = (float)InputVolumeSlider.Value;
            App.Options.Obj.OutputVolume = (float)OutputVolumeSlider.Value;

            App.Options.Update();

            CloseAudioSettings();
        }

        private void SettingsCloseAnim_Completed(object sender, EventArgs e)
        {
            AudioSettingsGroup.Visibility = Visibility.Hidden;
            AudioSettingsHeader.Text = "Audio Settings";
        }

        private void InputDeviceDropdown_DropDownClosed(object sender, EventArgs e)
        {
            App.Options.Obj.InputDevice = (string)InputDeviceDropdown.SelectedItem;
            App.Options.Update();

            App.NewInputDevice = App.Options.Obj.InputDevice;
        }

        private void OutputDeviceDropdown_DropDownClosed(object sender, EventArgs e)
        {
            App.Options.Obj.OutputDevice = (string)OutputDeviceDropdown.SelectedItem;
            App.Options.Update();

            App.NewOutputDevice = App.Options.Obj.OutputDevice;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            IsOpen = false;
            MainWindow.mainWindow.ConnectButton.IsEnabled = true;
        }

        // Settings Cog Mouse Enter
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var storyBoard = (Storyboard)FindResource("SettingsMouseOver");

            if (storyBoard != null)
                storyBoard.Begin();
        }

        // Settings Cog Mouse Leave
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var storyBoard = (Storyboard)FindResource("SettingsMouseLeave");

            if (storyBoard != null)
                storyBoard.Begin();
        }

        // Settings Cog Mouse Click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenAudioSettings();
        }

        private void Mute_Click_1(object sender, RoutedEventArgs e)
        {
            App.MicMuted = !App.MicMuted;

            switch(App.MicMuted)
            {
                case true:
                    MuteMicIcon.Source = _micMutedImage;
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
                    break;

                case false:
                    MuteMicIcon.Source = _micUnmutedImage;
                    MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));

                    if (App.Deafened)
                    {
                        App.Deafened = false;
                        DeafenIcon.Source = _speakerUnmutedImage;
                        SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));
                    }
                    break; 
            }
        }

        private void UserPanelClosed_Completed(object sender, EventArgs e)
        {
            UserControlPanel.Visibility = Visibility.Hidden;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UserPanelOpen)
            {
                if (!UserControlPanel.IsMouseOver)
                {
                    
                    if (App.VoiceChatWindow.FindResource("UserPanelCloseAnim") is Storyboard closeAnim)
                    {
                        closeAnim.Begin();
                    }

                    UserPanelOpen = false;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ConnectButton.IsEnabled = false;
            VoiceActivityBar.Value = Math.Clamp(App.Options.Obj.VoiceActivity, 0, 3000);
        }

        private void Menu_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            App.Client.DisconnectClient("", false);
        }

        private void Deafen_Click(object sender, RoutedEventArgs e)
        {
            App.Deafened = !App.Deafened;

            switch (App.Deafened)
            {
                case true:
                    DeafenIcon.Source = _speakerMutedImage;
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
                    break;

                case false:
                    DeafenIcon.Source = _speakerUnmutedImage;
                    SpeakerDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(127, 46, 219));
                    break;
            }

            if (App.Deafened)
            {
                App.MicMuted = true;
                MuteMicIcon.Source = _micMutedImage;
                MicDecibalMeter.Foreground = new SolidColorBrush(Color.FromRgb(74, 74, 87));
            }
                
        }

        private bool isVoiceMouseDown = false;

        private void VoiceActivityBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var relativePoint = Mouse.GetPosition(VoiceActivityBar);
            VoiceActivityBar.Value = Math.Clamp(relativePoint.X / VoiceActivityBar.Width * 3000, 0, 3000);

            isVoiceMouseDown = true;
        }

        private void VoiceActivityBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isVoiceMouseDown = false;

            // Update the voice activity value now so we aren't constantly doing I/O for no reason while dragging the bar.
            App.Options.Obj.VoiceActivity = (float)VoiceActivityBar.Value;
        }

        private void VoiceActivityBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isVoiceMouseDown)
            {
                var relativePoint = Mouse.GetPosition(VoiceActivityBar);
                VoiceActivityBar.Value = Math.Clamp(relativePoint.X / VoiceActivityBar.Width * 3000, 0, 3000);

                App.VoiceActivity = (float)VoiceActivityBar.Value;
            }
        }

        private void VoiceActivityBar_MouseLeave(object sender, MouseEventArgs e)
        {
            isVoiceMouseDown = false;
        }
    }
}
