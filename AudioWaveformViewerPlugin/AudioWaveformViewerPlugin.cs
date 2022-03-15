using Occlusion_voice_chat.Opus;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_voice_chat_CrossPlatform.plugin.api;
using Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI;

namespace AudioWaveformViewerPlugin;

public class AudioWaveformViewerPlugin : Plugin
{
    public override string PluginName { get; } = "Audio Waveform Viewer Plugin";

    public override int MaxVersion => -1;

    public override int MinVersion => 5;

    public override IList<ButtonWrapper> MenuButtons { get; set; } = new List<ButtonWrapper>();

    public override string PluginVersion => "1.0.0";

    public override void Load()
    {
        // Hook onto the audio processing event and mix in a basic sine wave
        AudioAPI.HookProcessAudioOutputEvent(AudioOutputProcess);
        
        // Add a button to the menu
        MenuButtons.Add(new ButtonWrapper("Open Waveform Viewer", "WaveformViewerButton"));
    }

    public override void Unload()
    {
        // Nothing to do
    }

    private short[] shortAudio;

    private float sinOffset = 0;

    private void AudioOutputProcess(Span<byte> audio)
    {
        
    }
}