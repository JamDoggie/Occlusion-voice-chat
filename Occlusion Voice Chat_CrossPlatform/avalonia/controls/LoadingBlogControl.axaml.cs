using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;

public class LoadingBlogControl : UserControl
{
    public LoadingBlogControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}