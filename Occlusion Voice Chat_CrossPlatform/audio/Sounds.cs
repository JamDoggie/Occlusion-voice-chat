using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public static OggSoundFile PushMuteSound;
        public static OggSoundFile PushUnmuteSound;

        public static OggSoundFile WavesSound;


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
            string dir = Directory.GetCurrentDirectory();

            Console.WriteLine($"{dir}/resources/occlusion_mute.opus bruh");
            Debug.WriteLine($"{dir}/resources/occlusion_mute.opus bruh");

            MicMuteSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_mute.opus");
            MicUnmuteSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_unmute.opus");
            DeafenSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_deafen.opus");
            UndeafenSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_undeafen.opus");

            PushMuteSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_pushmute.opus");
            PushUnmuteSound = OggSoundFile.LoadSound($"{dir}/resources/occlusion_pushunmute.opus");

            WavesSound = OggSoundFile.LoadSound($"{dir}/resources/waves_sample.opus", 1); 
        }
    }
}
