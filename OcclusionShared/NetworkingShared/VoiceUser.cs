
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
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using ReactiveUI;
using Avalonia.Controls;
using OxyPlot.Series;
using System.Numerics;
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

        public float AutoDisconnectCount { get; set; } = -1;

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
                        azimuth = value;

                        if (leftFilterArray != null)
                        {
                            PopulateHRTFs(elevation, azimuth, ref leftFilterArray, ref rightFilterArray);
                            copyFiltersToFloatArrays();
                            leftConvolver.ChangeKernel(leftFloatFilter);
                            rightConvolver.ChangeKernel(rightFloatFilter);
                        }
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
                        elevation = value;

                        if (leftFilterArray != null)
                        {
                            PopulateHRTFs(elevation, azimuth, ref leftFilterArray, ref rightFilterArray);
                            copyFiltersToFloatArrays();
                            leftConvolver.ChangeKernel(leftFloatFilter);
                            rightConvolver.ChangeKernel(rightFloatFilter);
                        }
                    }
                    
                }
                
            }
        }

        private Vector2 earDelays { get; set; } = new Vector2(0, 0);

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

        private static int activeQueueIndexOffset = App.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(50), App.samplingRate, 1);

        private int _queueOffset = activeQueueIndexOffset;
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
                    if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsVisible && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                    {
                        if (value)
                        {
                            if (MainWindow.mainWindow.VoiceChatWindow.GetPlayerIconByUUID(MCUUID) != null)
                                MainWindow.mainWindow.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness =
                                                                new Thickness(5);
                        }
                        else
                        {
                            if (MainWindow.mainWindow.VoiceChatWindow.GetPlayerIconByUUID(MCUUID) != null && MainWindow.mainWindow.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness.Left != 0)
                            {
                                MainWindow.mainWindow.VoiceChatWindow.GetPlayerIconByUUID(MCUUID).VoiceActivityBorder.BorderThickness =
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
                        _queueOffset = activeQueueIndexOffset; 
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
        private byte[] leftQueueArray = null;
        private byte[] rightQueueArray = null;
        private short[] queuedLeftShortArray = null;
        private short[] queuedRightShortArray = null;

        private short[] destinationShorts = null;

        private short[] processedAudio = null;

        private int[] leftSignal = null;
        private int[] rightSignal = null;

        private OlsBlockConvolver leftConvolver;
        private OlsBlockConvolver rightConvolver;

        private DiscreteSignal leftSig;
        private DiscreteSignal rightSig;

        

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
                    if (leftQueueArray == null || leftQueueArray.Length != destination.Length)
                    {
                        leftQueueArray = new byte[destination.Length / 2]; // Divide by 2 because we're mixing out stereo audio, yet the input microphone audio is currently in mono.
                        rightQueueArray = new byte[destination.Length / 2];

                        queuedLeftShortArray = new short[leftQueueArray.Length / 2];
                        queuedRightShortArray = new short[leftQueueArray.Length / 2];
                    }

                    if (processedAudio == null || processedAudio.Length != destination.Length / 2)
                    {
                        processedAudio = new short[destination.Length / 2];
                    }

                    if (destinationShorts == null || destinationShorts.Length != destination.Length / 2)
                    {
                        destinationShorts = new short[destination.Length / 2];
                    }

                    if (leftAudioArray == null || rightAudioArray == null)
                    {
                        leftAudioArray = new short[queuedLeftShortArray.Length];
                        rightAudioArray = new short[queuedRightShortArray.Length];

                        leftSignal = new int[queuedLeftShortArray.Length];
                        rightSignal = new int[queuedRightShortArray.Length];
                    }

                    if (App.Options.Obj.UseHRTF && leftConvolver == null || rightConvolver == null)
                    {
                        // Copy in HRTF filters.
                        PopulateHRTFs(elevation, azimuth, ref leftFilterArray, ref rightFilterArray);


                        leftConvolver = new OlsBlockConvolver(leftFilterArray, 1024);
                        
                        rightConvolver = new OlsBlockConvolver(rightFilterArray, 1024);
                    }

                    if (leftSig == null)
                        leftSig = new DiscreteSignal(App.samplingRate, leftSignal);

                    if (rightSig == null)
                        rightSig = new DiscreteSignal(App.samplingRate, rightSignal);
        #endregion


        #region Clear Arrays
                    for (int i = 0; i < leftQueueArray.Length; i++)
                    {
                        leftQueueArray[i] = 0;
                        rightQueueArray[i] = 0;
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
                            leftQueueArray[i] = MicQueue[Math.Clamp(i + activeQueueIndexOffset - ((int)earDelays.X * 2), 0, MicQueue.Length)];

                            rightQueueArray[i] = MicQueue[Math.Clamp(i + activeQueueIndexOffset - ((int)earDelays.Y * 2), 0, MicQueue.Length)];
                            amountCut++;
                        }
                    }

                    AudioMath.CopyBytesToShorts(queuedLeftShortArray, leftQueueArray);
                    AudioMath.CopyBytesToShorts(queuedRightShortArray, rightQueueArray);


                    // Move everything in the Mic Queue left the amount of bytes that we have mixed into the speakers.
                    for (int i = 0; i < MicQueue.Length; i++)
                    {
                        if (i + amountCut < MicQueue.Length)
                            MicQueue[i] = MicQueue[i + amountCut];
                    }

                    // Now, set the leftover bytes at the end of the array to silence so if we run out of things to mix we don't end up mixing in
                    // ghost audio samples from the past.
                    for (int i = MicQueue.Length - 1; i >= MicQueue.Length - amountCut; i--)
                    {
                        MicQueue[i] = 0;
                    }

                    _queueOffset -= amountCut;

                    if (_queueOffset < activeQueueIndexOffset)
                        _queueOffset = activeQueueIndexOffset;

                    for (int i = 0; i < queuedLeftShortArray.Length; i++)
                    {
                        leftSignal[i] = queuedLeftShortArray[i];
                        rightSignal[i] = queuedRightShortArray[i];
                    }
        #endregion


        #region Voice Activity
                    // Voice activity
                    AudioChunk stereoChunk = new AudioChunk(queuedLeftShortArray, App.samplingRate);
                    if (stereoChunk.Volume() < 10)
                    {
                        if (!IsLocalClient && App.EnableVoiceIconMeterOnClients)
                            IsTalking = false;
                    }
        #endregion


        #region Audio Processing
        #region HRTF
                    // Fill left and right audio arrays
                    for (int i = 0; i < queuedLeftShortArray.Length; i++)
                    {
                        leftAudioArray[i] = queuedLeftShortArray[i];
                        rightAudioArray[i] = queuedRightShortArray[i];
                    }

                    // Apply HRTFs to the audio arrays
                    if (App.Options.Obj.UseHRTF)
                    {
                        for (int i = 0; i < leftSignal.Length; i++)
                            leftSig[i] = leftSignal[i];

                        for (int i = 0; i < rightSignal.Length; i++)
                            rightSig[i] = rightSignal[i];

                        float leftDelay = leftSig.Length;
                        float rightDelay = rightSig.Length;

                        if (earDelays != null)
                        {
                            leftDelay += earDelays.X;
                            rightDelay += earDelays.Y;
                        }

                        for (int i = 0; i < leftSig.Samples.Length; i++)
                            leftSig[i] = leftConvolver.Process(leftSig[i]);

                        for (int i = 0; i < rightSig.Samples.Length; i++)
                            rightSig[i] = rightConvolver.Process(rightSig[i]);

                        for (int i = 0; i < leftAudioArray.Length; i++)
                        {
                            leftAudioArray[i] = AudioMath.ClampShort(leftSig[i] * DistanceVolume, short.MinValue, short.MaxValue);
                        }

                        for (int i = 0; i < rightAudioArray.Length; i++)
                        {
                            rightAudioArray[i] = AudioMath.ClampShort(rightSig[i] * DistanceVolume, short.MinValue, short.MaxValue);
                        }
                    }
                    
        #endregion

                    // Convert mic from mono input (one channel) to stereo output (two channels)
                    float rightOffset = 1f + (Pan);
                    float leftOffset = 1f - (Pan);

                    int k = 0;
                    for (int i = 0; i < processedAudio.Length / 2; i++)
                    {
                        
                        if (App.Options.Obj.UseHRTF)
                        {
                            processedAudio[k] = leftAudioArray[i];
                            processedAudio[k + 1] = rightAudioArray[i];
                        }
                        else
                        {
                            processedAudio[k] = AudioMath.AmplifyShort(queuedLeftShortArray[i], leftOffset);
                            processedAudio[k + 1] = AudioMath.AmplifyShort(queuedRightShortArray[i], rightOffset);
                        }

                        k += 2;
                    }

#if HRTFDEBUG
                    // Debug code to draw a graph of the HRTFs when we're looking at a user's user panel.
                    // This does not compile in release mode.
                    if (App.Options.Obj.UseHRTF)
                        Dispatcher.UIThread.InvokeAsync(() => {
                            if (MainWindow.mainWindow.VoiceChatWindow != null && MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                            {
                                VoiceChatControl voiceWindow = MainWindow.mainWindow.VoiceChatWindow;

                                if (voiceWindow.UserPanelOpen && voiceWindow.UserControlPanel.UUID == MCUUID)
                                    if (voiceWindow.UserControlPanel.DataContext is UserPanelViewModel viewModel)
                                    {
                                        foreach (Series series in viewModel.PlotModelLeft.Series)
                                        {
                                            if (series is LineSeries lines)
                                            {
                                                lines.Points.Clear();
                                                for (int i = 0; i < leftFilterArray.Length; i++)
                                                {
                                                    lines.Points.Add(new OxyPlot.DataPoint(i, leftFilterArray[i]));
                                                }
                                            }
                                        }

                                        foreach (Series series in viewModel.PlotModelRight.Series)
                                        {
                                            if (series is LineSeries lines)
                                            {
                                                lines.Points.Clear();
                                                for (int i = 0; i < rightFilterArray.Length; i++)
                                                {
                                                    lines.Points.Add(new OxyPlot.DataPoint(i, rightFilterArray[i]));
                                                }
                                            }
                                        }

                                        viewModel.PlotModelLeft.InvalidatePlot(true);
                                        viewModel.PlotModelRight.InvalidatePlot(true);
                                    }
                            }
                        });

#endif
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


        // ReSharper disable once InconsistentNaming
        private void PopulateHRTFs(float elev, float azim, ref double[] leftArray, ref double[] rightArray, float distance = 2000)
        {
            // Use our loaded .mhr HRTF file.
            if (HRTF.CurrentHRTFFile != null)
            {
                var delays = HRTF.CurrentHRTFFile.GenerateHRTFS(elev, azim, ref leftArray, ref rightArray, distance);

                if (delays != null)
                    earDelays = delays.Value;
            }
            // We don't have a loaded HRTF preset. Fall back to the MIT Kemar data set.
            else
            {
                if (earDelays != Vector2.Zero)
                    earDelays = Vector2.Zero;

                var taps = HRTF.mit_hrtf_availability((int)azim, (int)elev, App.samplingRate);

                if (leftArray.Length != taps)
                    leftArray = new double[taps];

                if (rightArray.Length != taps)
                    rightArray = new double[taps];

                int iAzi = (int)azim;
                int iElev = (int)elev;

                HRTF.mit_hrtf_get(ref iAzi, ref iElev, App.samplingRate, 0, ref leftArray, ref rightArray);
            }
        }
#endif
    }
}
