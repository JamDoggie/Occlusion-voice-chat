using Occlusion_voice_chat.Opus;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_voice_chat_CrossPlatform.plugin.api;

namespace WhiteNoiseExamplePlugin;

public class WhiteNoiseExamplePlugin : Plugin
{
    public string PluginName { get; set; } = "White Noise Example Plugin";

    public int MaxVersion => -1;

    public int MinVersion => 5;

    public string PluginVersion { get; set; } = "1.0.0";

    public void Load()
    {
        // Hook onto the audio processing event and mix in some basic white noise
        AudioAPI.HookProcessAudioOutputEvent(AudioOutputProcess);
    }


    private short[] shortAudio;

    private Random rand = new Random();
    
    private void AudioOutputProcess(Span<byte> audio)
    {
        // Convert the byte array to a short array so we can process it
        AudioMath.CopyBytesToShorts(shortAudio, audio);
        
        // Mix in white noise to shortAudio
        for (int i = 0; i < shortAudio.Length; i++)
        {
            shortAudio[i] = (short) Math.Clamp(shortAudio[i] + rand.Next(-2500, 2500), short.MinValue, short.MaxValue);
        }
        
        // Copy the newly mixed audio back into our audio array.
        AudioMath.CopyShortsToBytes(audio, shortAudio);
    }
    
    public void Unload()
    {
        
    }
    
    
}