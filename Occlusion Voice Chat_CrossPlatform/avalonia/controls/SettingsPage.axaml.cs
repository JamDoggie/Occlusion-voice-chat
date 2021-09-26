using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
