using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using DynamicData;
using DynamicData.Binding;
using JetBrains.Annotations;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.audio;
using OcclusionMixerPlugin.json;
using ReactiveUI;

namespace OcclusionMixerPlugin.viewmodels;

public class MixingWindowViewModel : ReactiveObject
{
    public MixingWindow MixingWindow { get; set; }
    
    public ObservableCollection<MixerSound> SoundFiles { get; } = new();

    public MixingWindowViewModel()
    {
        foreach(MixerSound s in MixingWindow.Settings.Obj.SoundFiles)
        {
            SoundFiles.Add(s);
        }
    }
    
    public async void AddSoundCommand()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        // We want this file dialog to look for .opus files
        openFileDialog.Filters.Add(new FileDialogFilter
        {
            Extensions = new List<string> { "opus" },
            Name = "Ogg Opus Files"
        });

        openFileDialog.AllowMultiple = true;

        string[]? files = await openFileDialog.ShowAsync(MixingWindow);

        if (files != null && files.Length > 0)
        {
            foreach(string s in files)
            {
                if (SoundFiles.Any(sound => sound.Path == s))
                {
                    continue;
                }
                
                MixingWindow.Settings.Obj.SoundFiles.Add(new MixerSound(){Path = s, KeyBind = new List<string>()});
                MixingWindow.Settings.Save();
            }
            
            SoundFiles.Clear();
            foreach(MixerSound s in MixingWindow.Settings.Obj.SoundFiles)
            {
                SoundFiles.Add(s);
            }
        }
    }
    
    public void RemoveSoundCommand()
    {
        
    }
}
