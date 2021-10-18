using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class OcclusionBackground : UserControl
    {
        public OcclusionBackground()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
