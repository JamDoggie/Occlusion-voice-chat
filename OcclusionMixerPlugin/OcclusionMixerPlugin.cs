using ATL;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI;
using OcclusionMixerPlugin.json;

namespace OcclusionMixerPlugin;

public class OcclusionMixerPlugin : Plugin
{
    public override string PluginName => "Occlusion Mixer Plugin";

    public override int MaxVersion => -1;

    public override int MinVersion => 5;

    public override IList<ButtonWrapper> MenuButtons { get; set; } = new List<ButtonWrapper>();

    public override string PluginVersion => "1.0.0";

    private MixingWindow _mixingWindow = new MixingWindow();
    
    public static bool IsWindowOpen = false;
    
    private List<string> _currentKeyBind = new();
    
    public override void Load()
    {
        Console.WriteLine("Occlusion mixer plugin loaded!");

        ButtonWrapper mixerButton = new ButtonWrapper
            ("Open Mixing Board", "MixingBoardButton");
        
        MenuButtons.Add(mixerButton);
        
        mixerButton.SetClickHandler((o, e) =>
        {
            if (!IsWindowOpen)
            {
                _mixingWindow = new MixingWindow();
                _mixingWindow.Show();
                IsWindowOpen = true;
            }
               
        });
        
        if (App.KeybindManager.CurrentBindManager != null)
        {
            App.KeybindManager.CurrentBindManager.KeyDown += (o, e) =>
            {
                _currentKeyBind.Clear();
                foreach (KeyCode code in App.KeybindManager.CurrentBindManager.CurrentPressedKeys)
                {
                    _currentKeyBind.Add(code.ToString());
                }
                
                foreach(MixerSound sound in MixingWindow.Settings.Obj.SoundFiles)
                {
                    if (sound.KeyBind.Contains(e.ToString()))
                    {
                        int matchingKeys = 0;

                        foreach (string s in _currentKeyBind)
                        {
                            if (sound.KeyBind.Contains(s))
                                matchingKeys++;
                        }

                        if (matchingKeys == sound.KeyBind.Count && matchingKeys > 0)
                        {
                            MixingWindow.PlaySound(sound);
                            break;
                        }
                    }
                    
                }
            };
        }
    }

    public override void Unload()
    {
        
    }
}