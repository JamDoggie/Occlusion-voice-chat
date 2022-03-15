using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls.messagebox;

public class MessageBoxWindow : Window
{
    public MessageBoxModel ViewModel { get; set; } = new MessageBoxModel();
    
    public StackPanel ButtonsPanel { get; set; }
    
    public MessageBoxWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        DataContext = ViewModel;
        
#if WINDOWS
        uint attr = 19;
        int val = 1;
        _ = App.DwmSetWindowAttribute(PlatformImpl.Handle.Handle, attr, ref val, sizeof(int));
#endif

        ButtonsPanel = this.FindControl<StackPanel>("ButtonsPanel");
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}