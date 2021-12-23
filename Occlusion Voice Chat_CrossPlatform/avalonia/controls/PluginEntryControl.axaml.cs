using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using Occlusion_voice_chat_CrossPlatform.plugin;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class PluginEntryControl : UserControl
    {
        public PluginEntryViewModel ViewModel { get; set; } = new();
        
        public Plugin Plugin { get; set; }
        
        public PluginEntryControl()
        {
            InitializeComponent();

            DataContext = ViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
