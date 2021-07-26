
#if SERVER
using OcclusionServerLib.structs;
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiteNetLib;
using LiteNetLib.Utils;
#if CLIENT
using Avalonia.Threading;
using Occlusion_voice_chat.Opus;

#endif

#if CLIENT_CROSSPLATFORM
using Avalonia;
using Occlusion_Voice_Chat_CrossPlatform;
using System.Runtime.CompilerServices;
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
        public NetPeer Connection { get; set; }

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
        public byte[] MicQueue;

        public float ClientVolume { get; set; } = 1.0f;

        private DateTime _lastPanTime = DateTime.Now;
        private DateTime _lastDistTime = DateTime.Now;
        private float audioInterpolationStep = 6.5f;

        private float _panTarget = 1f;
        private float _currentPan = 1f;
        public float Pan
        {
            get => _currentPan;
            set
            {
                _panTarget = value;

                double deltaTime = (DateTime.Now - _lastPanTime).TotalSeconds;

                if (_panTarget < _currentPan)
                {
                    _currentPan -= audioInterpolationStep * (float)deltaTime;

                    _currentPan = Math.Max(_currentPan, _panTarget);
                }

                if (_panTarget > _currentPan)
                {
                    _currentPan += audioInterpolationStep * (float)deltaTime;

                    _currentPan = Math.Min(_currentPan, _panTarget);
                }

                _lastPanTime = DateTime.Now;
            }
        }

        private float _distTarget = 1f;
        private float _currentdist = 1f;
        public float DistanceVolume
        {
            get
            {
                return _currentdist;
            }

            set
            {
                _distTarget = value;

                double deltaTime = (DateTime.Now - _lastDistTime).TotalSeconds;

                if (_distTarget < _currentdist)
                {
                    _currentdist -= audioInterpolationStep * (float)deltaTime;

                    _currentdist = Math.Max(_currentdist, _distTarget);
                }

                if (_distTarget > _currentdist)
                {
                    _currentdist += audioInterpolationStep * (float)deltaTime;

                    _currentdist = Math.Min(_currentdist, _distTarget);
                }

                _lastDistTime = DateTime.Now;
            }
        }

        private int _queueOffset = 0;
        public int QueueOffset { get { return _queueOffset; } }

        private bool _isTalking = false;
        public bool IsTalking
        {
            get
            {
                return _isTalking;
            }
            
            set
            {
                _isTalking = value;
                
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (App.VoiceChatWindow != null && App.VoiceChatWindow.IsVisible && App.VoiceChatWindow.IsOpen)
                    {
                        if (value)
                        {
                            
                            App.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness =
                                                                new Thickness(5);
                        }
                        else
                        {
                            if (App.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness.Left != 0)
                            {
                                App.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness =
                                    new Thickness(0);
                            }
                        }
                    }
                });
                
            }
        }

        public bool IsLocalClient { get; set; } = false;
        
        private object _lockObj = new object();


        public void InitializeArrays()
        {
            MicQueue = new byte[App.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(500), App.samplingRate, 1)];
            micShorts = AudioMath.BytesToShorts(MicQueue);
            stereoMicShorts = new short[micShorts.Length * 2];
        }

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

        private short[] micShorts;
        private short[] stereoMicShorts;
        private short[] destinationShorts = null;
        private byte[] destBytes = null;
        private short[] queuedShorts = null;
        
        
        public void MixMicIntoSpanAndCutQueue(ref Span<byte> destination)
        {
            lock (_lockObj)
            {
                for(int i = 0; i < stereoMicShorts.Length; i++)
                {
                    stereoMicShorts[i] = 0;
                }

                if (_queueOffset > 0)
                {
                    int amountCut = 0;

                    if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                            IsTalking = true;

                    for (int c = 0; c < micShorts.Length; c++)
                    {
                        micShorts[c] = (short)(((int)MicQueue[(c * 2)]) << 0);
                        micShorts[c] += (short)(((int)MicQueue[(c * 2) + 1]) << 8);
                    }


                    // Convert mic from mono input (one channel) to stereo output (two channels)
                    float rightOffset = 1f + (Pan);
                    float leftOffset = 1f - (Pan);

                    int k = 0;
                    for (int i = 0; i < stereoMicShorts.Length / 2; i++)
                    {
                        stereoMicShorts[k] = AudioMath.AmplifyShort(micShorts[i], DistanceVolume * leftOffset);
                        stereoMicShorts[k + 1] = AudioMath.AmplifyShort(micShorts[i], DistanceVolume * rightOffset);

                        k += 2;
                    }

                    // First time initializations
                    if (destinationShorts == null)
                    {
                        destinationShorts = new short[destination.Length / sizeof(short)]; // sizeof(short) = 2
                        queuedShorts = new short[destinationShorts.Length];
                    }

                    if (destBytes == null)
                    {
                        destBytes = new byte[destination.Length];
                    }


                    for (int c = 0; c < destinationShorts.Length; c++)
                    {
                        destinationShorts[c] = (short)(((int)destination[(c * 2)]) << 0);
                        destinationShorts[c] += (short)(((int)destination[(c * 2) + 1]) << 8);
                    }

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

                    for (int c = 0; c < destinationShorts.Length; c++)
                    {
                        destBytes[c * 2] = (byte)(destinationShorts[c] & 0xFF);
                        destBytes[c * 2 + 1] = (byte)((destinationShorts[c] >> 8) & 0xFF);
                    }

                    for (int i = 0; i < destBytes.Length; i++)
                    {
                        destination[i] = destBytes[i];
                    }

                    // Voice activity
                    for(int i = 0; i < queuedShorts.Length; i++)
                    {
                        queuedShorts[i] = stereoMicShorts[i];
                    }

                    AudioChunk stereoChunk = new AudioChunk(queuedShorts, App.samplingRate);
                    if (stereoChunk.Volume() < 10)
                    {
                        if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                            IsTalking = false;
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
                else
                {
                    if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                        IsTalking = false;
                }
            }
        }
#endif
    }
}
