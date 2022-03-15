using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GlobalLowLevelHooks;
using Occlusion_voice_chat.util;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.audio;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using OcclusionMixerPlugin.audio;
using OcclusionMixerPlugin.json;
using OcclusionMixerPlugin.viewmodels;
using SdlSharp.Input;

namespace OcclusionMixerPlugin;

public class MixingWindow : Window
{
    public static JsonFile<MixerSettings> Settings = 
        new(Path.Combine(Directory.GetCurrentDirectory(), "mixer-settings.json"), new MixerSettings());

    public MixingWindowViewModel ViewModel { get; set; } = new MixingWindowViewModel();

    internal static SoundEffect? _currentSoundEffect;
    
    internal static SoundEffect? _currentPreviewSoundEffect;
    
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
        
        // This is for setting the title bar of the window to be the user's choice of dark or light theme.
        // File explorer uses this, but it works on other windows too.
        // *Note: actually, file explorer *used* this on Windows 10, doesn't on Windows 11.
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            uint attr = 19;
            int val = 1;
            _ = App.DwmSetWindowAttribute(PlatformImpl.Handle.Handle, attr, ref val, sizeof(int));
        }

        DataContext = ViewModel;
        ViewModel.MixingWindow = this;

        Closed += (o, e) =>
        {
            OcclusionMixerPlugin.IsWindowOpen = false;
        };

        ListBox listBox = this.FindControl<ListBox>("SoundList");
        
        this.FindControl<Button>("PlayButton").Click += (o, e) =>
        {
            if (listBox.SelectedItem is MixerSound sound)
                PlaySound(sound);
        };
        
        this.FindControl<Button>("StopButton").Click += (o, e) =>
        {
            _currentSoundEffect?.Stop();
            _currentPreviewSoundEffect?.Stop();
        };
        
        Slider soundVolume = this.FindControl<Slider>("SoundVolume");
        Slider previewVolume = this.FindControl<Slider>("PreviewVolume");

        soundVolume.Value = Settings.Obj.SoundVolume;
        previewVolume.Value = Settings.Obj.PreviewVolume;
        
        soundVolume.PropertyChanged += (o, e) =>
        {
            if (e.Property.Name == "Value")
            {
                Settings.Obj.SoundVolume = (float)soundVolume.Value;
                Settings.Save();
            }
        };
        
        previewVolume.PropertyChanged += (o, e) =>
        {
            if (e.Property.Name == "Value")
            {
                Settings.Obj.PreviewVolume = (float)previewVolume.Value;
                Settings.Save();
            }
        };
        
        HotkeyBindingControl playHotkey = this.FindControl<HotkeyBindingControl>("PlaySoundBind");
        HotkeyBindingControl stopHotkey = this.FindControl<HotkeyBindingControl>("StopSoundBind");
        
        listBox.SelectionChanged += (o, e) =>
        {
            if (listBox.SelectedItem is MixerSound sound)
            {
                playHotkey.IsEnabled = true;
                
                // Load the hotkey binding for the selected sound.
                try
                {
                    playHotkey.Hotkey.Clear();
                    foreach (string s in sound.KeyBind)
                        playHotkey.Hotkey.Add(Enum.Parse<KeyCode>(s));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error loading sound hotkey: \n" + ex.Message);
                }
                
                playHotkey.UpdateContent();
            }
            else
            {
                playHotkey.IsEnabled = false;
            }
        };
        
        // Load the stop sound hotkey
        try
        {
            stopHotkey.Hotkey.Clear();
            foreach (string s in Settings.Obj.StopSoundBind)
                stopHotkey.Hotkey.Add(Enum.Parse<KeyCode>(s));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error loading sound hotkey: \n" + ex.Message);
        }

        
        stopHotkey.UpdateContent();
        
        playHotkey.HotkeyChanged += hotkey =>
        {
            if (listBox.SelectedItem != null && listBox.SelectedItem is MixerSound sound)
            {
                sound.KeyBind = hotkey.Select(k => k.ToString()).ToList();
                Settings.Save();
            }
        };
        
        stopHotkey.HotkeyChanged += hotkey =>
        {
            Settings.Obj.StopSoundBind = hotkey.Select(k => k.ToString()).ToList();
            Settings.Save();
        };

        

        stopHotkey.HotkeyPressed += () =>
        {
            _currentSoundEffect?.Stop();
            _currentPreviewSoundEffect?.Stop();
        };
        
    }

    public static void PlaySound(MixerSound sound)
    {
        _currentSoundEffect?.Stop(); // Stop the current sound effect if there is one playing.
        _currentPreviewSoundEffect?.Stop(); // Stop the current preview sound effect if there is one playing.
            
        _currentSoundEffect = new MicrophoneOggSound(sound.Path, Settings.Obj.SoundVolume);
        _currentSoundEffect.Play();
            
        _currentPreviewSoundEffect = new OggOpusSoundEffect(sound.Path, Settings.Obj.PreviewVolume);
        _currentPreviewSoundEffect.Play();
    }
}