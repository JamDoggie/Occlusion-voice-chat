using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public static class Sounds
    {
        public static OggSoundFile MicMuteSound;
        public static OggSoundFile MicUnmuteSound;
        public static OggSoundFile DeafenSound;
        public static OggSoundFile UndeafenSound;


        private static object _soundLock = new object();
        private static List<SoundEffect> _activeSounds = new();
        public static List<SoundEffect> ActiveSounds
        {
            get
            {
                lock(_soundLock)
                {
                    return _activeSounds;
                }
            }

            set
            {
                lock (_soundLock)
                {
                    _activeSounds = value;
                }
            }
        }  

        public static void LoadSounds()
        {
            MicMuteSound = OggSoundFile.LoadSound("resources/occlusion_mute.opus");
            MicUnmuteSound = OggSoundFile.LoadSound("resources/occlusion_unmute.opus");
            DeafenSound = OggSoundFile.LoadSound("resources/occlusion_deafen.opus");
            UndeafenSound = OggSoundFile.LoadSound("resources/occlusion_undeafen.opus");
        }
    }
}
