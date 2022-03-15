using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls.messagebox;

public class MessageBoxWindow : Window
{
    public MessageBoxWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}