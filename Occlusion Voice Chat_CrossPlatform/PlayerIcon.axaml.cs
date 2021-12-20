using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Occlusion_voice_chat.Mojang;
using System;
using Avalonia.Media;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class PlayerIcon : UserControl
    {
        #region Controls
        public Grid PlayerIconButton;
        public Image PlayerIconImg;
        public Grid BackgroundGrid;
        public TextBlock PlayerName;
        public Button IconButton;
        public Border VoiceActivityBorder;
        #endregion

        public int PlayerID { get; set; } = -1;

        public string UUID { get; set; }

        public PlayerIcon()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            PlayerIconButton = this.FindControl<Grid>("PlayerIconButton");
            PlayerIconImg = this.FindControl<Image>("PlayerIconImg");
            BackgroundGrid = this.FindControl<Grid>("BackgroundGrid");
            PlayerName = this.FindControl<TextBlock>("PlayerName");
            IconButton = this.FindControl<Button>("IconButton");
            VoiceActivityBorder = this.FindControl<Border>("VoiceActivityBorder");
            
            PlayerIconButton.PointerPressed += Button_Click;
            PlayerIconButton.PointerEnter += PlayerIconButtonOnPointerEnter;
            PlayerIconButton.PointerLeave += PlayerIconButtonOnPointerLeave;
        }

        private void PlayerIconButtonOnPointerLeave(object? sender, PointerEventArgs e)
        {
            PlayerName.Opacity = 0;

            if (PlayerName.RenderTransform is TranslateTransform transform)
            {
                transform.Y = 0;
            }

            BackgroundGrid.Height = 0;
        }

        private void PlayerIconButtonOnPointerEnter(object? sender, PointerEventArgs e)
        {
            BackgroundGrid.Height = 20;
            
            if (PlayerName.RenderTransform is TranslateTransform transform)
            {
                transform.Y = -3;
            }
            
            PlayerName.Opacity = 1;
        }
        
        public void InitImages()
        {
            if (PlayerIconImg.Source is Bitmap)
            {
                Image_DownloadCompleted();
            }
        }

        private void Image_DownloadCompleted()
        {
            CroppedBitmap cropped = new CroppedBitmap((Bitmap)PlayerIconImg.Source, new PixelRect(8, 8, 8, 8));
            PlayerIconImg.Source = cropped;
        }
        
        private async void Button_Click(object sender, PointerPressedEventArgs e)
        {
            MainWindow.mainWindow.VoiceChatWindow.UserControlPanel.UserNameText.Text = await PlayerCache.GetCachedPlayerUsername(UUID);
            MainWindow.mainWindow.VoiceChatWindow.UserControlPanel.UUIDText.Text = UUID;
            MainWindow.mainWindow.VoiceChatWindow.UserControlPanel.UUID = UUID;

            MainWindow.mainWindow.VoiceChatWindow.UserControlPanel.Opacity = 1;
            
            Point relativePoint = Bounds.Position;

            Canvas.SetTop(MainWindow.mainWindow.VoiceChatWindow.UserControlPanel, relativePoint.Y + PlayerIconButton.Height + 20);
            Canvas.SetLeft(MainWindow.mainWindow.VoiceChatWindow.UserControlPanel, relativePoint.X + 10);


            float userVolume;
            if (!App.Options.Obj.UserVolumes.TryGetValue(UUID, out userVolume))
            {
                userVolume = 1;
            }

            MainWindow.mainWindow.VoiceChatWindow.UserControlPanel.VolumeSlider.Value = userVolume;


            MainWindow.mainWindow.VoiceChatWindow.UserPanelOpen = true;
        }
    }
}
