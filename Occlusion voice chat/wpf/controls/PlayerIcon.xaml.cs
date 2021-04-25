using Occlusion_voice_chat.Mojang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Occlusion_voice_chat.wpf.controls
{
    /// <summary>
    /// Interaction logic for PlayerIcon.xaml
    /// </summary>
    public partial class PlayerIcon : UserControl
    {
        public int PlayerID { get; set; } = -1;

        public string UUID { get; set; }

        public PlayerIcon()
        {
            InitializeComponent();
        }

        public void InitImages()
        {
            if (PlayerIconImg.Source is BitmapImage image)
            {
                if (image.IsDownloading)
                {
                    image.DownloadCompleted += Image_DownloadCompleted;
                }
                else
                {
                    Image_DownloadCompleted(null, null);
                }
            }
        }

        private void Image_DownloadCompleted(object sender, EventArgs e)
        {
            CroppedBitmap cropped = new CroppedBitmap((BitmapImage)PlayerIconImg.Source, new Int32Rect(8,8,8,8));
            PlayerIconImg.Source = cropped;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            var storyBoard = (Storyboard)FindResource("TextAnimTransformIn");

            if (storyBoard != null)
                storyBoard.Begin();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            var storyBoard = (Storyboard)FindResource("TextAnimTransformOut");

            if (storyBoard != null)
                storyBoard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.VoiceChatWindow.UserControlPanel.UserNameText.Text = PlayerCache.GetCachedPlayerUsername(UUID);
            App.VoiceChatWindow.UserControlPanel.UUIDText.Text = UUID;
            App.VoiceChatWindow.UserControlPanel.UUID = UUID;

            App.VoiceChatWindow.UserControlPanel.Visibility = Visibility.Visible;

            if (App.VoiceChatWindow.FindResource("UserPanelOpenAnim") is Storyboard openAnim)
            {
                openAnim.Begin();
            }

            Point relativePoint = PlayerIconButton.TransformToAncestor(App.VoiceChatWindow.PlayerIconsPanel)
                          .Transform(new Point(0, 0));

            Console.WriteLine($"{relativePoint.X}, {relativePoint.Y}");

            Canvas.SetTop(App.VoiceChatWindow.UserControlPanel, relativePoint.Y + PlayerIconButton.Height + 10);
            Canvas.SetLeft(App.VoiceChatWindow.UserControlPanel, relativePoint.X);


            float userVolume;
            if(!App.Options.Obj.UserVolumes.TryGetValue(UUID, out userVolume))
            {
                userVolume = 1;
            }

            App.VoiceChatWindow.UserControlPanel.VolumeSlider.Value = userVolume;


            App.VoiceChatWindow.UserPanelOpen = true;
        }
    }
}
