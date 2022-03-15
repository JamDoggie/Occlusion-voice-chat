using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OcclusionMixerPlugin;

public class MixingWindow : Window
{
    public MixingWindow()
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