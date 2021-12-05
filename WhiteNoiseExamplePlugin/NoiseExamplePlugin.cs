using System;
using Occlusion_voice_chat.Opus;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_voice_chat_CrossPlatform.plugin.api;

namespace NoiseExamplePlugin
{
    public class NoiseExamplePlugin : Plugin
    {
        public string PluginName { get; set; } = "Noise Example Plugin";

        public int MaxVersion => -1;

        public int MinVersion => 5;

        public string PluginVersion { get; set; } = "1.0.0";

        public override void Load()
        {
            Console.WriteLine("Example plugin has been loaded!");

            // Hook onto the audio processing event and mix in some basic white noise
            AudioAPI.HookProcessAudioOutputEvent(AudioOutputProcess);
        }

        public override void Unload()
        {
            Console.WriteLine("Example plugin has been unloaded.");
        }

        private short[] shortAudio;

        private Random rand = new Random();

        private float sinOffset = 0;

        private void AudioOutputProcess(Span<byte> audio)
        {
            if (shortAudio == null || shortAudio.Length != audio.Length / 2)
            {
                shortAudio = new short[audio.Length / 2];
            }

            // Convert the byte array to a short array so we can process it
            AudioMath.CopyBytesToShorts(shortAudio, audio);

            // Get a random wave length for our sine wave
            int wavelength = 1;
            float volume = 1200f;

            // Mix in white noise to shortAudio
            for (int i = 0; i < shortAudio.Length; i++)
            {
                shortAudio[i] = (short) Math.Clamp(shortAudio[i] + (Math.Sin(sinOffset * wavelength) * volume), short.MinValue, short.MaxValue);
                sinOffset += 0.01f;
            }

        

            // Copy the newly mixed audio back into our audio array.
            AudioMath.CopyShortsToBytes(audio, shortAudio);
        }
    
    
    }
}

