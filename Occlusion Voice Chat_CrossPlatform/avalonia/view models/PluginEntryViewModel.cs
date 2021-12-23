using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Occlusion_voice_chat_CrossPlatform.plugin;
using ReactiveUI;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;

public class PluginEntryViewModel : ReactiveObject
{
    private Bitmap _pluginIcon = PluginManager.DefaultIcon;
    public Bitmap PluginIcon
    {
        get => _pluginIcon;
        set => this.RaiseAndSetIfChanged(ref _pluginIcon, value);
    }
    
    private string _pluginName = "...";
    public string PluginName
    {
        get => _pluginName;
        set => this.RaiseAndSetIfChanged(ref _pluginName, value);
    }

    private string _pluginVersion = "?.?.?";
    public string PluginVersion
    {
        get => _pluginVersion;
        set => this.RaiseAndSetIfChanged(ref _pluginVersion, value);
    }
}