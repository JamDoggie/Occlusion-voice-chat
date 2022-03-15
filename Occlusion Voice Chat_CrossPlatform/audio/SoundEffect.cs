using Occlusion_voice_chat.Opus;
using OcclusionShared.NetworkingShared;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public abstract class SoundEffect
    {
        public bool IsPlaying { get; internal set; } = false;

        public float Volume { get; set; } = 1.0f;

        public bool Loop { get; set; } = false;
        
        public SoundEffect()
        {

        }

        public SoundEffect(float volume)
        {
            Volume = volume;
        }

        /// <summary>
        /// Plays the sound from the current position in our stream.
        /// </summary>
        public virtual void Play()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                
                Sounds.ActiveSounds.Add(this);
            }
        }

        /// <summary>
        /// Pauses the sound, and resets the audio stream to the beginning.
        /// </summary>
        public virtual void Stop()
        {
            IsPlaying = false;
        }        
        
        /// <summary>
        /// Mixes the audio into the given ref Span<byte>, preserving the audio that is already in the Span<byte>.
        /// The base of this method does nothing by default.
        /// </summary>
        /// <param name="destination"></param>
        public virtual void MixAudioIntoSpan(ref Span<byte> destination)
        {

        }
    }
}
