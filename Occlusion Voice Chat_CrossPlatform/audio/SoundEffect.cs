using Occlusion_voice_chat.Opus;
using OcclusionShared.NetworkingShared;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public class SoundEffect
    {
        public short[] AudioData { get; set; }

        public bool IsPlaying { get; private set; } = false;

        public float Volume { get; set; } = 1.0f;

        private int _queueOffset = 0;

        private object _queueLock = new object();

        public SoundEffect()
        {

        }

        public SoundEffect(OggSoundFile file, float volume = 1f)
        {
            AudioData = new short[file.AudioData.Length];

            for(int i = 0; i < file.AudioData.Length; i++)
            {
                AudioData[i] = file.AudioData[i];
            }

            Volume = volume;
        }

        public void Play()
        {
            lock(_queueLock)
            {
                if (!IsPlaying)
                {
                    if (AudioData != null)
                    {
                        _queueOffset = 0;

                        IsPlaying = true;
                    }

                    Sounds.ActiveSounds.Add(this);
                }
                
            }
            
        }

        public void MixAudioIntoArray(ref Span<byte> destination)
        {
            lock(_queueLock)
            {
                #region Grab Audio From Queue
                int amountCut = 0;
                
                for (int i = 0; i < destination.Length / 2; i++)
                {
                    if (i < AudioData.Length - _queueOffset)
                    {
                        int currentDataOffset = i + _queueOffset;

                        short currentDestinationValue = 0;
                        short currentSampleValue = AudioMath.AmplifyShort(AudioData[currentDataOffset], Volume);

                        // Convert from bytes to short
                        currentDestinationValue = (short)(((int)destination[(i * 2)]) << 0);
                        currentDestinationValue += (short)(((int)destination[(i * 2) + 1]) << 8);


                        // Mix them
                        short finalSample = (short)(Math.Clamp(currentDestinationValue + currentSampleValue, short.MinValue, short.MaxValue));

                        // Convert back to bytes and set in destination
                        destination[i * 2] = (byte)(finalSample & 0xFF);
                        destination[i * 2 + 1] = (byte)((finalSample >> 8) & 0xFF);

                        amountCut += 1;
                    }
                }

                _queueOffset += amountCut;

                if (_queueOffset >= AudioData.Length)
                {
                    _queueOffset = AudioData.Length - 1;
                    IsPlaying = false;
                }
                    
                #endregion
            }
        }
    }
}
