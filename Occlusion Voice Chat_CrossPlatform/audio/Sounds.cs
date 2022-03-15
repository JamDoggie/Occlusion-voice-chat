using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public static class Sounds
    {
        public static string MicMuteSound;
        public static string MicUnmuteSound;
        public static string DeafenSound;
        public static string UndeafenSound;

        public static string PushMuteSound;
        public static string PushUnmuteSound;

        public static string WavesSound;
        public static string DrumSound;


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

            // Check if this code is running in the avalonia designer
            if (Design.IsDesignMode)
            {
                dir = AppContext.BaseDirectory;
            }

            Console.WriteLine($"{dir}/resources/occlusion_mute.opus bruh");
            Debug.WriteLine($"{dir}/resources/occlusion_mute.opus bruh");

            MicMuteSound = $"{dir}/resources/occlusion_mute.opus";
            MicUnmuteSound = $"{dir}/resources/occlusion_unmute.opus";
            DeafenSound = $"{dir}/resources/occlusion_deafen.opus";
            UndeafenSound = $"{dir}/resources/occlusion_undeafen.opus";

            PushMuteSound = $"{dir}/resources/occlusion_pushmute.opus";
            PushUnmuteSound = $"{dir}/resources/occlusion_pushunmute.opus";

            WavesSound = $"{dir}/resources/waves_sample.opus"; 
            DrumSound = $"{dir}/resources/occlusion_drum_pattern.opus"; 
        }
    }
}
