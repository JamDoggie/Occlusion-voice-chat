using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Occlusion_voice_chat.Mojang;
using System;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class PlayerIcon : UserControl
    {
        #region Controls
        public Grid PlayerIconButton;
        public Image PlayerIconImg;
        public Grid BackgroundGrid;
        public TextBlock PlayerName;
        #endregion

        public int PlayerID { get; set; } = -1;

        public string UUID { get; set; }

        public PlayerIcon()
        {
            InitializeComponent();
#if DEBUG
            //this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            PlayerIconButton = this.FindControl<Grid>("PlayerIconButton");
            PlayerIconImg = this.FindControl<Image>("PlayerIconImg");
            BackgroundGrid = this.FindControl<Grid>("BackgroundGrid");
            PlayerName = this.FindControl<TextBlock>("PlayerName");

            PlayerIconButton.PointerPressed += Button_Click;
        }

        // NOTE: Come back to this, as there is no DownloadCompleted event in Avalonia.
        public void InitImages()
        {
            if (PlayerIconImg.Source is Bitmap)
            {
                Image_DownloadCompleted(null, null);
            }
        }

        private void Image_DownloadCompleted(object sender, EventArgs e)
        {
            CroppedBitmap cropped = new CroppedBitmap((Bitmap)PlayerIconImg.Source, new PixelRect(8, 8, 8, 8));
            PlayerIconImg.Source = cropped;
        }
        
        // NOTE: come back to this
        private void Button_Click(object sender, PointerPressedEventArgs e)
        {
            App.VoiceChatWindow.UserControlPanel.UserNameText.Text = PlayerCache.GetCachedPlayerUsername(UUID);
            App.VoiceChatWindow.UserControlPanel.UUIDText.Text = UUID;
            App.VoiceChatWindow.UserControlPanel.UUID = UUID;

            App.VoiceChatWindow.UserControlPanel.Opacity = 1;
            
            Point relativePoint = Bounds.Position;

            Canvas.SetTop(App.VoiceChatWindow.UserControlPanel, relativePoint.Y + PlayerIconButton.Height + 20);
            Canvas.SetLeft(App.VoiceChatWindow.UserControlPanel, relativePoint.X + 10);


            float userVolume;
            if (!App.Options.Obj.UserVolumes.TryGetValue(UUID, out userVolume))
            {
                userVolume = 1;
            }

            App.VoiceChatWindow.UserControlPanel.VolumeSlider.Value = userVolume;


            App.VoiceChatWindow.UserPanelOpen = true;
        }
    }
}
