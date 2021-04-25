using OcclusionShared.NetworkingShared;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Occlusion_voice_chat.wpf.controls
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {
        public string UUID { get; set; }

        public UserPanel()
        {
            InitializeComponent();
        }

        private void VolumeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            // Save the new volume for this user in the options file, with their UUID as the key.
            if (!string.IsNullOrEmpty(UUID))
            {
                App.Options.Obj.UserVolumes[UUID] = (float)VolumeSlider.Value;

                App.Options.Update();
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen)
            {
                VolumeText.Text = (int)(VolumeSlider.Value * 100) + "%";

                // Update the user volume in the program
                if (!string.IsNullOrEmpty(UUID))
                {
                    VoiceUser user = App.GetUserByUUID(UUID);
                    if (user != null)
                    {
                        user.ClientVolume = (float)VolumeSlider.Value;
                    }
                }
            }
                
        }
    }
}
