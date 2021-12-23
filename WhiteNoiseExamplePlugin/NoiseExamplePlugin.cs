using System;
using GlobalLowLevelHooks;
using Occlusion_voice_chat.Opus;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Occlusion_voice_chat_CrossPlatform.plugin.api;
using Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI;

namespace NoiseExamplePlugin
{
    public class NoiseExamplePlugin : Plugin
    {
        public override string PluginName { get; } = "Noise Example Plugin";

        public override int MaxVersion => -1;

        public override int MinVersion => 5;

        public override IList<ButtonWrapper> MenuButtons { get; set; } = new List<ButtonWrapper>();

        public override string PluginVersion => "1.0.0";

        public override void Load()
        {
            Console.WriteLine("Example plugin has been loaded!");

            // Hook onto the audio processing event and mix in a basic sine wave
            AudioAPI.HookProcessAudioOutputEvent(AudioOutputProcess);
            
            // Add a button to the menu
            MenuButtons.Add(new ButtonWrapper("Noise Example", "NoiseExampleButton"));
        }

        public override void Unload()
        {
            Console.WriteLine("Example plugin has been unloaded.");
            // Nothing to do
        }

        private short[] shortAudio;

        private float sinOffset = 0;

        private void AudioOutputProcess(Span<byte> audio)
        {
            // When CTRL is pressed (on Windows, as VKeys is for Win32 keycodes), a sine wave will play.
            if (App.KeybindManager.CurrentBindManager != null && App.KeybindManager.CurrentBindManager
            .CurrentPressedKeys.Contains(KeyCode.LCONTROL))
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

                // Mix in our sine wav to shortAudio
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
}

