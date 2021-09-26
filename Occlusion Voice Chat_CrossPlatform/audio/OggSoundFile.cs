using Concentus.Oggfile;
using Concentus.Structs;
using Occlusion_voice_chat.Opus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public class OggSoundFile
    {
        public short[] AudioData { get; set; }

        public string VendorString { get; set; }

        public List<string> UserComments { get; set; }

        public int Channels { get; set; }

        /// <summary>
        /// This loads an audio file as a sound effect. Currently the only supported format is:
        ///  | OGG Opus (not Vorbis) |
        ///  | 48000 hz |
        ///
        /// If you would like to load an audio container of your choice, there is a seperate method that you can plug the raw PCM data into.
        /// 
        /// This class is currently not made for anything but the in built sound effects, and as such if you for whatever reason need more support for more formats,
        /// you can either make a Github issue or pull request.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OggSoundFile LoadSound(string path, int channels = 2)
        {
            OggSoundFile effect = new OggSoundFile();
            effect.Channels = channels;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                OpusDecoder decoder = OpusDecoder.Create(48000, channels);
                OpusOggReadStream oggIn = new OpusOggReadStream(decoder, fileStream);

                List<short> audioData = new();

                while (oggIn.HasNextPacket)
                {
                    short[] packet = oggIn.DecodeNextPacket();
                    if (packet != null)
                    {
                        for (int i = 0; i < packet.Length; i++)
                        {
                            audioData.Add(packet[i]);
                        }
                    }
                }

                effect.AudioData = new short[audioData.Count];
                
                for(int i = 0; i < audioData.Count; i++)
                {
                    effect.AudioData[i] = audioData[i];
                }
            }
            
            return effect;
        }
    }
}
