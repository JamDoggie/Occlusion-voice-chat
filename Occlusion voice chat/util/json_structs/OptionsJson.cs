using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.util.json_structs
{
    public class OptionsJson
    {
        public string InputDevice { get; set; } = "Default";

        public string OutputDevice { get; set; } = "Default";

        public float InputVolume { get; set; } = 1;

        public float OutputVolume { get; set; } = 1;

        public float VoiceActivity { get; set; } = 500;

        public Dictionary<string, float> UserVolumes { get; set; } = new Dictionary<string, float>();
    }
}
