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

        /// <summary>
        /// This loads an audio file as a sound effect. Currently the only supported format is:
        ///  | OGG Opus (not Vorbis) |
        ///  | 48000 hz |
        ///
        /// If these requirements aren't met, it will throw a not implemented exception.
        /// If you would like to load an audio container of your choice, there is a seperate method that you can plug the raw PCM data into.
        /// 
        /// This class is currently not made for anything but the in built sound effects, and as such if you for whatever reason need more support for more formats,
        /// you can either make a Github issue or pull request.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OggSoundFile LoadSound(string path)
        {
            OggSoundFile effect = new OggSoundFile();

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                OpusDecoder decoder = OpusDecoder.Create(48000, 2);
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
            

            /*using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                /// HEADER \\\
                byte[] headerBytes = reader.ReadBytes(4);

                string headerString = Encoding.UTF8.GetString(headerBytes);

                if (headerString != "OggS")
                    throw new FormatException($"Given file at path \"{path}\" is not a valid OGG file. If it should be, it may be corrupt.");

                byte streamStructureVersion = reader.ReadByte();
                byte headerTypeFlag = reader.ReadByte();
                long absoluteGranulePosition = reader.ReadInt64();
                int streamSerialNumber = reader.ReadInt32();
                int pageSequenceNo = reader.ReadInt32();
                int checksum = reader.ReadInt32();
                byte page_segments = reader.ReadByte();

                List<int> packetLengths = new();

                int currentPacketLength = 0;

                for(int i = 0; i < page_segments; i++)
                {
                    byte length = reader.ReadByte();

                    currentPacketLength += length;
                    
                    if (length < 255)
                    {
                        packetLengths.Add(currentPacketLength);
                        currentPacketLength = 0;
                    }
                
                }

                List<short> audioData = new();

                for (int i = 0; i < packetLengths.Count; i++)
                {
                    byte[] bytes = reader.ReadBytes(packetLengths[i]);

                    bool isPacket = true;

                    if (bytes.Length >= 8)
                    {
                        byte[] byteHeader = new byte[8];

                        for(int j = 0; j < 8; j++)
                        {
                            byteHeader[j] = bytes[j];
                        }

                        string byteHeaderString = Encoding.UTF8.GetString(byteHeader);

                        if (byteHeaderString == "OpusHead" || byteHeaderString == "OpusTags")
                        {
                            isPacket = false;
                        }
                    }

                    

                    if (isPacket)
                    {
                        AudioChunk chunk = effect.codec.Decompress(bytes);
                        for(int j = 0; j < chunk.Data.Length; j++)
                        {
                            audioData.Add(chunk.Data[j]);
                        }
                    }
                        
                }

                effect.AudioData = new short[audioData.Count];

                for (int i = 0; i < audioData.Count; i++)
                    effect.AudioData[i] = audioData[i];
            }*/

            return effect;
        }
    }
}
