using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AudioWaveformViewerPlugin.windows;

public class Waveform_Window : Window
{
    public Waveform_Window()
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