using Lidgren.Network;
#if SERVER
using OcclusionServerLib.structs;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if CLIENT
using SdlSharp.Sound;
using Occlusion_voice_chat.Opus;
using System.Collections.Concurrent;
using Occlusion_voice_chat;
#endif

namespace OcclusionShared.NetworkingShared
{
    public class VoiceUser
    {
        #region shared
        public int id { get; set; }

        public int verificationCode { get; set; } = -1;

        public string MCUUID { get; set; }
        #endregion

#if SERVER
        public NetConnection Connection { get; set; }

        public bool IsVerified { get; set; } = false;

        private object location_lock = new object();

        private PlayerLocation? _location = null;
        public PlayerLocation? Location 
        { 
            get 
            {
                lock(location_lock)
                {
                    return _location;
                }
            } 
            set 
            {
                lock (location_lock)
                {
                    _location = value;
                }
            } 
        }




#endif

#if CLIENT
        public OpusCodec codec { get; set; }

        private byte[] _micQueue;
        public byte[] MicQueue
        {
            get
            {
                lock (_lockObj)
                    return _micQueue;
            }

            set
            {
                lock (_lockObj)
                    _micQueue = value;
            }
        }

        public float ClientVolume { get; set; } = 1.0f;

        public float Pan { get; set; } = 1f;

        public float DistanceVolume { get; set; } = 1f;

        private int _queueOffset = 0;
        public int QueueOffset { get { return _queueOffset; } }

        private object _lockObj = new object();


        public void QueueAudio(Span<byte> audio)
        {
            lock(_lockObj)
            {
                if (MicQueue != null)
                {
                    for(int i = _queueOffset; i < _queueOffset + audio.Length; i++)
                    {
                        if (i < MicQueue.Length)
                        {
                            MicQueue[i] = audio[i - _queueOffset];
                        }
                    }

                    _queueOffset += audio.Length;

                    // If the audio queue gets this big, we need to clear it to sync things back up.
                    if (_queueOffset > MicQueue.Length)
                    {
                        _queueOffset = 0; 
                        for (int i = 0; i < MicQueue.Length; i++)
                            MicQueue[i] = 0;
                    }
                }
            }
        }

        public void MixMicIntoSpanAndCutQueue(ref Span<byte> destination)
        {
            lock (_lockObj)
            {
                if (_queueOffset > 0)
                {
                    int amountCut = 0;

                    short[] micShorts;
                    short[] destinationShorts;

                    micShorts = AudioMath.BytesToShorts(MicQueue);

                    // Convert mic from mono input(one channel) to stereo output(two channels)
                    short[] stereoMicShorts = new short[micShorts.Length * 2];

                    float rightOffset = 1f + (Pan);
                    float leftOffset = 1f - (Pan);

                    int k = 0;
                    for (int i = 0; i < stereoMicShorts.Length / 2; i++)
                    {
                        AudioChunk leftChunk = new AudioChunk(micShorts[i], App.samplingRate).Amplify(DistanceVolume);
                        AudioChunk rightChunk = new AudioChunk(micShorts[i], App.samplingRate).Amplify(DistanceVolume);

                        leftChunk = leftChunk.Amplify(leftOffset);

                        rightChunk = rightChunk.Amplify(rightOffset);

                        stereoMicShorts[k] = leftChunk.Data[0];
                        stereoMicShorts[k + 1] = rightChunk.Data[0];

                        k += 2;
                    }

                    destinationShorts = AudioMath.BytesToShorts(destination.ToArray());

                    for (int i = 0; i < destinationShorts.Length; i++)
                    {
                        if (i < stereoMicShorts.Length)
                        {
                            // This mixes the two audio streams together using (A + B) - (A * B)
                            // This isn't the ideal mixing solution, but since this isn't super high quality audio or music to begin with,
                            // i'm ok with it for now. In the future, i could explore mixing using tanh, however i'm not completely sure where to begin with that.
                            //
                            // This is also based off of the example from this link https://atastypixel.com/blog/how-to-mix-audio-samples-properly-on-ios/
                            int mixedValue;
                            if (stereoMicShorts[i] < 0 && destinationShorts[i] < 0)
                            {
                                mixedValue = (destinationShorts[i] + stereoMicShorts[i]) - ((destinationShorts[i] * stereoMicShorts[i]) / short.MinValue);
                            }
                            else if (stereoMicShorts[i] > 0 && destinationShorts[i] > 0)
                            {
                                mixedValue = (destinationShorts[i] + stereoMicShorts[i]) - ((destinationShorts[i] * stereoMicShorts[i]) / short.MaxValue);
                            }
                            else
                            {
                                mixedValue = destinationShorts[i] + stereoMicShorts[i];
                            }

                            // When we mix these together, they might reach below or above the int16 limits, so we need to clip the audio.
                            // A simple Math.Clamp will suffice.
                            destinationShorts[i] = (short)Math.Clamp(mixedValue, short.MinValue, short.MaxValue);
                        }
                    }

                    var destBytes = AudioMath.ShortsToBytes(destinationShorts);

                    for(int i = 0; i < destBytes.Length; i++)
                    {
                        destination[i] = destBytes[i];
                    }


                    for (int i = 0; i < destination.Length / 2; i++)
                    {
                        if (i < MicQueue.Length)
                        {
                            amountCut++;
                        }
                    }


                    // Move everything in the array left the amount of bytes that we have mixed into the speakers.
                    for (int i = 0; i < MicQueue.Length; i++)
                    {
                        if (i + amountCut < MicQueue.Length)
                            MicQueue[i] = MicQueue[i + amountCut];
                    }

                    // Now, set the leftover bytes at the end of the array to silence so if we run out of things to mix we don't end up mixing in ghost audio samples from the past.
                    for(int i = MicQueue.Length - 1; i >= MicQueue.Length - amountCut; i--)
                    {
                        MicQueue[i] = 0;
                    }

                    _queueOffset -= amountCut;

                    if (_queueOffset < 0)
                        _queueOffset = 0;
                }
                
            }
        }
#endif
    }
}
