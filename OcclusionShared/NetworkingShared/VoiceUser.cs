
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
using Occlusion_Voice_Chat_CrossPlatform.HRTF;
using NWaves.Filters.Base;
using NWaves.Signals;
using NWaves.Operations.Convolution;
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

        public int CurrentBitrate { get; set; } = 64; // Kbps


#endif

#if CLIENT
        public OpusCodec codec { get; set; }

        private byte[] _micQueue;
        public byte[] MicQueue;

        public float ClientVolume { get; set; } = 1.0f;

        private float azimuth = 0.0f;
        public float Azimuth
        {
            get => azimuth;
            set
            {
                lock (_lockObj)
                {
                    if (value != azimuth)
                    {
                        if (leftFilterArray != null)
                        {
                            int iAzimuth = (int)azimuth;
                            int iElevation = (int)elevation;
                            HRTF.mit_hrtf_get(ref iAzimuth, ref iElevation, App.samplingRate, 1, ref leftFilterArray, ref rightFilterArray);
                            copyFiltersToFloatArrays();
                            leftConvolver.ChangeKernel(leftFloatFilter);
                            rightConvolver.ChangeKernel(rightFloatFilter);
                        }

                        azimuth = value;
                    }
                }
            }
        }

        private float elevation = 0.0f;
        public float Elevation
        {
            get => elevation;
            set
            {
                lock(_lockObj)
                {
                    if (value != elevation)
                    {
                        if (leftFilterArray != null)
                        {
                            int iAzimuth = (int)azimuth;
                            int iElevation = (int)elevation;
                            HRTF.mit_hrtf_get(ref iAzimuth, ref iElevation, App.samplingRate, 1, ref leftFilterArray, ref rightFilterArray);
                            copyFiltersToFloatArrays();
                            leftConvolver.ChangeKernel(leftFloatFilter);
                            rightConvolver.ChangeKernel(rightFloatFilter);
                        }

                        elevation = value;
                    }
                    
                }
                
            }
        }


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

        

        // HRTF
        private double[] leftFilterArray = null;
        private double[] rightFilterArray = null;

        private float[] leftFloatFilter = null;
        private float[] rightFloatFilter = null;

        private short[] leftAudioArray = null;
        private short[] rightAudioArray = null;


        private short[] firOutputArray = null;

        // Cached audio arrays for processing.
        private byte[] queueArray = null;
        private short[] queuedShortArray = null;

        private short[] destinationShorts = null;

        private short[] processedAudio = null;

        private float[] leftSignal = null;
        private float[] rightSignal = null;

        private int? taps = null;

        private FirFilter leftConvolver;
        private FirFilter rightConvolver;


        private void copyFiltersToFloatArrays()
        {
            if (leftFloatFilter == null || leftFloatFilter.Length != leftFilterArray.Length)
                leftFloatFilter = new float[leftFilterArray.Length];

            if (rightFloatFilter == null || rightFloatFilter.Length != rightFilterArray.Length)
                rightFloatFilter = new float[rightFilterArray.Length];

            for (int i = 0; i < leftFilterArray.Length; i++)
                leftFloatFilter[i] = (float)leftFilterArray[i];

            for (int i = 0; i < rightFilterArray.Length; i++)
                rightFloatFilter[i] = (float)rightFilterArray[i];
        }

        public void MixMicIntoSpanAndCutQueue(ref Span<byte> destination)
        {
            lock (_lockObj)
            {
                if (_queueOffset > 0)
                {
                    // HRTF init
                    int azimuth = (int)Azimuth;
                    int elevation = (int)Elevation;

                    azimuth = Math.Clamp(azimuth, -180, 180);

                    elevation = Math.Clamp(elevation, -40, 90);


                    #region Array Initializations
                    if (queueArray == null || queueArray.Length != destination.Length)
                    {
                        queueArray = new byte[destination.Length / 2]; // Divide by 2 because we're mixing out stereo audio, yet the input microphone audio is currently in mono.
                        queuedShortArray = new short[queueArray.Length / 2];
                    }

                    if (processedAudio == null || processedAudio.Length != destination.Length / 2)
                    {
                        processedAudio = new short[destination.Length / 2];
                    }

                    if (destinationShorts == null || destinationShorts.Length != destination.Length / 2)
                    {
                        destinationShorts = new short[destination.Length / 2];
                    }

                    if (leftFilterArray == null || rightFilterArray == null)
                    {
                        taps = HRTF.mit_hrtf_availability(azimuth, elevation, App.samplingRate);

                        leftFilterArray = new double[taps.Value];
                        rightFilterArray = new double[taps.Value];
                    }

                    if (leftAudioArray == null || rightAudioArray == null)
                    {
                        leftAudioArray = new short[queuedShortArray.Length];
                        rightAudioArray = new short[queuedShortArray.Length];

                        leftSignal = new float[queuedShortArray.Length];
                        rightSignal = new float[queuedShortArray.Length];
                    }

                    if (leftConvolver == null || rightConvolver == null)
                    {
                        // Copy in HRTF filters.
                        HRTF.mit_hrtf_get(ref azimuth, ref elevation, App.samplingRate, 1, ref leftFilterArray, ref rightFilterArray);

                        TransferFunction leftFunction = new TransferFunction(leftFilterArray);
                        TransferFunction rightFunction = new TransferFunction(rightFilterArray);

                        leftConvolver = new FirFilter(leftFunction);
                        rightConvolver = new FirFilter(rightFunction);
                    }
                    #endregion


                    #region Clear Arrays
                    for (int i = 0; i < queueArray.Length; i++)
                    {
                        queueArray[i] = 0;
                    }

                    for (int i = 0; i < processedAudio.Length; i++)
                    {
                        processedAudio[i] = 0;
                    }

                    AudioMath.CopyBytesToShorts(destinationShorts, destination);
                    #endregion


                    #region Grab Audio From Queue
                    int amountCut = 0;

                    for (int i = 0; i < destination.Length / 2; i++)
                    {
                        if (i < MicQueue.Length)
                        {
                            queueArray[i] = MicQueue[i];
                            amountCut++;
                        }
                    }

                    AudioMath.CopyBytesToShorts(queuedShortArray, queueArray);


                    // Move everything in the Mic Queue left the amount of bytes that we have mixed into the speakers.
                    for (int i = 0; i < MicQueue.Length; i++)
                    {
                        if (i + amountCut < MicQueue.Length)
                            MicQueue[i] = MicQueue[i + amountCut];
                    }

                    // Now, set the leftover bytes at the end of the array to silence so if we run out of things to mix we don't end up mixing in ghost audio samples from the past.
                    for (int i = MicQueue.Length - 1; i >= MicQueue.Length - amountCut; i--)
                    {
                        MicQueue[i] = 0;
                    }

                    _queueOffset -= amountCut;

                    if (_queueOffset < 0)
                        _queueOffset = 0;

                    for (int i = 0; i < queuedShortArray.Length; i++)
                    {
                        leftSignal[i] = AudioMath.ClampShortToFloat(queuedShortArray[i]);
                        rightSignal[i] = AudioMath.ClampShortToFloat(queuedShortArray[i]);
                    }
                    #endregion


                    #region Voice Activity
                    // Voice activity
                    AudioChunk stereoChunk = new AudioChunk(queuedShortArray, App.samplingRate);
                    if (stereoChunk.Volume() < 10)
                    {
                        if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                            IsTalking = false;
                    }
                    #endregion


                    #region Audio Processing
                    #region HRTF
                    // Fill left and right audio arrays
                    for (int i = 0; i < queuedShortArray.Length; i++)
                    {
                        leftAudioArray[i] = queuedShortArray[i];
                        rightAudioArray[i] = queuedShortArray[i];
                    }

                    // Apply HRTFs to the audio arrays
                    DiscreteSignal leftSig = new DiscreteSignal(App.samplingRate, leftSignal);
                    DiscreteSignal rightSig = new DiscreteSignal(App.samplingRate, rightSignal);
                    
                    leftSig = leftConvolver.ProcessChunks(leftSig, leftSig.Length);
                    rightSig = rightConvolver.ProcessChunks(rightSig, rightSig.Length);

                    for(int i = 0; i < leftAudioArray.Length; i++)
                    {
                        leftAudioArray[i] = AudioMath.AmplifyShort(AudioMath.ExpandFloatToShort(leftSig[i]), DistanceVolume);
                    }

                    for (int i = 0; i < rightAudioArray.Length; i++)
                    {
                        rightAudioArray[i] = AudioMath.AmplifyShort(AudioMath.ExpandFloatToShort(rightSig[i]), DistanceVolume);
                    }
                    #endregion

                    // Convert mic from mono input (one channel) to stereo output (two channels)
                    float rightOffset = 1f + (Pan);
                    float leftOffset = 1f - (Pan);

                    int k = 0;
                    for (int i = 0; i < processedAudio.Length / 2; i++)
                    {
                        //processedAudio[k] = AudioMath.AmplifyShort(queuedShortArray[i], DistanceVolume * leftOffset);
                        //processedAudio[k + 1] = AudioMath.AmplifyShort(queuedShortArray[i], DistanceVolume * rightOffset);

                        processedAudio[k] = leftAudioArray[i];
                        processedAudio[k + 1] = rightAudioArray[i];

                        k += 2;
                    }
                    #endregion
                    

                    #region Mixing
                    for (int i = 0; i < destinationShorts.Length; i++)
                    {
                        if (i < processedAudio.Length)
                        {
                            // This mixes the two audio streams together using (A + B) - (A * B)
                            // This isn't the ideal mixing solution, but since this isn't super high quality audio or music to begin with,
                            // i'm ok with it for now. In the future, i could explore mixing using tanh, however i'm not completely sure where to begin with that.
                            //
                            // This is also based off of the example from this link https://atastypixel.com/blog/how-to-mix-audio-samples-properly-on-ios/
                            int mixedValue;
                            if (processedAudio[i] < 0 && destinationShorts[i] < 0)
                            {
                                mixedValue = (destinationShorts[i] + processedAudio[i]) - ((destinationShorts[i] * processedAudio[i]) / short.MinValue);
                            }
                            else if (processedAudio[i] > 0 && destinationShorts[i] > 0)
                            {
                                mixedValue = (destinationShorts[i] + processedAudio[i]) - ((destinationShorts[i] * processedAudio[i]) / short.MaxValue);
                            }
                            else
                            {
                                mixedValue = destinationShorts[i] + processedAudio[i];
                            }

                            // When we mix these together, they might reach below or above the int16 limits, so we need to clip the audio.
                            // A simple Math.Clamp will suffice.
                            destinationShorts[i] = (short)Math.Clamp(mixedValue, short.MinValue, short.MaxValue);
                        }
                    }

                    AudioMath.CopyShortsToBytes(destination, destinationShorts);
                    #endregion
                }
                else
                {
                    if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                        IsTalking = false;
                }
            }
        }

        /// <summary>
        /// Applies FIR filter to the given audio.
        /// WARNING: This uses a cached array for the return value. Use the value one at a time or copy the array contents out somewhere else.
        /// </summary>
        /// <param name="b">The filter.</param>
        /// <param name="x">The input audio.</param>
        /// <returns></returns>
        public short[] FIR(double[] b, short[] x)
        {
            int M = b.Length;
            int n = x.Length;

            if (firOutputArray == null || firOutputArray.Length != n)
                firOutputArray = new short[n];

            var y = firOutputArray;
            for (int yi = 0; yi < n; yi++)
            {
                short t = 0;
                for (int bi = M - 1; bi >= 0; bi--)
                {
                    if (yi - bi < 0) continue;

                    t += (short)(b[bi] * x[yi - bi]);
                }
                y[yi] = t;
            }
            return y;
        }
#endif
    }
}
