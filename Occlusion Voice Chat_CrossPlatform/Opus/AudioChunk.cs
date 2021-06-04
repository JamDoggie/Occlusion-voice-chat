using Occlusion_Voice_Chat_CrossPlatform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.Opus
{
    public struct AudioChunk
    {
        public short[] Data;
        public int SampleRate;

        /// <summary>
        /// Creates a new audio sample from a 2-byte little endian array
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="sampleRate"></param>
        public AudioChunk(byte[] rawData, int sampleRate)
            : this(AudioMath.BytesToShorts(rawData), sampleRate)
        {
        }

        /// <summary>
        /// Creates a new audio sample from a base64-encoded chunk representing a 2-byte little endian array
        /// </summary>
        /// <param name="base64Data"></param>
        /// <param name="sampleRate"></param>
        public AudioChunk(string base64Data, int sampleRate)
            : this(Convert.FromBase64String(base64Data), sampleRate)
        {
        }

        /// <summary>
        /// Creates a new audio sample from a linear set of 16-bit samples
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="sampleRate"></param>
        public AudioChunk(short[] rawData, int sampleRate)
        {
            Data = rawData;
            SampleRate = sampleRate;
        }

        public AudioChunk(short dataSample, int sampleRate)
        {
            Data = new short[1];
            Data[0] = dataSample;

            SampleRate = sampleRate;
        }

        public byte[] GetDataAsBytes()
        {
            return AudioMath.ShortsToBytes(Data);
        }

        public string GetDataAsBase64()
        {
            return Convert.ToBase64String(GetDataAsBytes());
        }

        public AudioChunk Amplify(float amount)
        {
            short[] amplifiedData = new short[DataLength];
            for (int c = 0; c < amplifiedData.Length; c++)
            {
                float newVal = (float)Data[c] * amount;
                if (newVal > short.MaxValue)
                    amplifiedData[c] = short.MaxValue;
                else if (newVal < short.MinValue)
                    amplifiedData[c] = short.MinValue;
                else
                    amplifiedData[c] = (short)newVal;
            }
            return new AudioChunk(amplifiedData, SampleRate);
        }

        public float Peak()
        {
            float highest = 0;
            for (int c = 0; c < Data.Length; c++)
            {
                float test = Math.Abs((float)Data[c]);
                if (test > highest)
                    highest = test;
            }
            return highest;
        }

        public double Volume()
        {
            double curVolume = 0;
            // No Enumerable.Average function for short values, so do it ourselves
            for (int c = 0; c < Data.Length; c++)
            {
                if (Data[c] == short.MinValue)
                    curVolume += short.MaxValue;
                else
                    curVolume += Math.Abs(Data[c]);
            }
            curVolume /= DataLength;
            return curVolume;
        }

        public AudioChunk Normalize()
        {
            double volume = Peak();
            return Amplify(short.MaxValue / (float)volume);
        }

        public int DataLength
        {
            get
            {
                return Data.Length;
            }
        }

        public TimeSpan Length
        {
            get
            {
                return TimeSpan.FromMilliseconds((double)Data.Length * 1000 / SampleRate);
            }
        }

        public AudioChunk Concatenate(AudioChunk other)
        {
            AudioChunk toConcatenate = other;
            int combinedDataLength = DataLength + toConcatenate.DataLength;
            short[] combinedData = new short[combinedDataLength];
            Array.Copy(Data, combinedData, DataLength);
            Array.Copy(toConcatenate.Data, 0, combinedData, DataLength, toConcatenate.DataLength);
            return new AudioChunk(combinedData, SampleRate);
        }
    }
}
