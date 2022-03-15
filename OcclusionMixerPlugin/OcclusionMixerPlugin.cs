using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI;

namespace OcclusionMixerPlugin;

public class OcclusionMixerPlugin : Plugin
{
    public override string PluginName => "Occlusion Mixer Plugin";

    public override int MaxVersion => -1;

    public override int MinVersion => 5;

    public override IList<ButtonWrapper> MenuButtons { get; set; } = new List<ButtonWrapper>();

    public override string PluginVersion => "1.0.0";

    public override void Load()
    {
        Console.WriteLine("Occlusion mixer plugin loaded!");

        ButtonWrapper mixerButton = new ButtonWrapper
            ("Open Mixing Board", "MixingBoardButton");
        
        MenuButtons.Add(mixerButton);
        
        mixerButton.SetClickHandler((o, e) =>
        {
            
        });
    }

    public override void Unload()
    {
        
    }
}