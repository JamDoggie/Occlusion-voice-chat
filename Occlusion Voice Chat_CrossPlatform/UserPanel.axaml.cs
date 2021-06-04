#nullable disable

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using OcclusionShared.NetworkingShared;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class UserPanel : UserControl
    {
        public string UUID { get; set; }

        #region Controls
        public Slider VolumeSlider;

        public TextBlock VolumeText;

        public TextBlock UserNameText;

        public TextBox UUIDText;
        #endregion

        public UserPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            VolumeSlider = this.FindControl<Slider>("VolumeSlider");
            VolumeText = this.FindControl<TextBlock>("VolumeText");
            UserNameText = this.FindControl<TextBlock>("UserNameText");
            UUIDText = this.FindControl<TextBox>("UUIDText");

            PropertyChanged += UserPanel_PropertyChanged;

            VolumeSlider.PropertyChanged += VolumeSlider_ValueChanged;
        }

        private void UserPanel_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (e.Property == Grid.OpacityProperty)
            {
                if (e.Priority == BindingPriority.Animation && (double)e.OldValue != 0 && (double)e.NewValue == 0)
                {
                    IsVisible = false;
                }

                if ((double)e.OldValue == 0 && (double)e.NewValue != 0)
                {
                    IsVisible = true;
                }
            }

        }

        private void VolumeSlider_DragCompleted(object sender, PointerReleasedEventArgs e)
        {
            
        }

        private void VolumeSlider_ValueChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Slider.ValueProperty)
            {
                // Save the new volume for this user in the options file, with their UUID as the key.
                if (!string.IsNullOrEmpty(UUID))
                {
                    App.Options.Obj.UserVolumes[UUID] = (float)VolumeSlider.Value;

                    App.Options.Update();
                }

                if (App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen)
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
}
