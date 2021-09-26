using Occlusion_voice_chat.Opus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Occlusion_Voice_Chat_CrossPlatform.HRTF;
using NWaves.Operations.Convolution;
using NWaves.Signals;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public class HRTFTestSoundEffect : SoundEffect
    {
        public bool Muted = true;

        public byte[] AudioBytes;

        private float azimuth = 0.0f;
        public float Azimuth
        {
            get => azimuth;
            set
            {
                lock (_queueLock)
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
                lock (_queueLock)
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

        public HRTFTestSoundEffect(OggSoundFile file, float volume = 1f)
        {
            AudioData = new short[file.AudioData.Length];

            for (int i = 0; i < file.AudioData.Length; i++)
            {
                AudioData[i] = file.AudioData[i];
            }

            Volume = volume;
        }

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

        public override void Play()
        {
            if (!IsPlaying)
            {
                _queueOffset = 0;

                AudioBytes = AudioMath.ShortsToBytes(AudioData);

                IsPlaying = true;
                

                Sounds.ActiveSounds.Add(this);
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

        private int[] leftSignal = null;
        private int[] rightSignal = null;

        private OlsBlockConvolver leftConvolver;
        private OlsBlockConvolver rightConvolver;

        private DiscreteSignal leftSig;
        private DiscreteSignal rightSig;

        public override void MixAudioIntoArray(ref Span<byte> destination)
        {
            lock (_queueLock)
            {
                if (_queueOffset >= 0 && !Muted && App.VoiceChatWindow != null && App.VoiceChatWindow.IsOpen && App.VoiceChatWindow.AudioSettingsOpen)
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

                    if (leftAudioArray == null || rightAudioArray == null)
                    {
                        leftAudioArray = new short[queuedShortArray.Length];
                        rightAudioArray = new short[queuedShortArray.Length];

                        leftSignal = new int[queuedShortArray.Length];
                        rightSignal = new int[queuedShortArray.Length];
                    }

                    if (leftConvolver == null || rightConvolver == null)
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
                        var offset = i + _queueOffset;

                        if (offset < AudioBytes.Length)
                        {
                            queueArray[i] = AudioBytes[offset];
                            amountCut++;
                        }
                    }

                    AudioMath.CopyBytesToShorts(queuedShortArray, queueArray);


                    _queueOffset += amountCut;

                    if (_queueOffset >= AudioBytes.Length)
                        _queueOffset = 0;

                    for (int i = 0; i < queuedShortArray.Length; i++)
                    {
                        leftSignal[i] = queuedShortArray[i];
                        rightSignal[i] = queuedShortArray[i];
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
                    for (int i = 0; i < leftSignal.Length; i++)
                        leftSig[i] = leftSignal[i];

                    for (int i = 0; i < rightSignal.Length; i++)
                        rightSig[i] = rightSignal[i];

                    float leftDelay = leftSig.Length;
                    float rightDelay = rightSig.Length;

                    for (int i = 0; i < leftSig.Samples.Length; i++)
                        leftSig[i] = leftConvolver.Process(leftSig[i]);

                    for (int i = 0; i < rightSig.Samples.Length; i++)
                        rightSig[i] = rightConvolver.Process(rightSig[i]);

                    for (int i = 0; i < leftAudioArray.Length; i++)
                    {
                        leftAudioArray[i] = AudioMath.ClampShort(leftSig[i] * Volume, short.MinValue, short.MaxValue);
                    }

                    for (int i = 0; i < rightAudioArray.Length; i++)
                    {
                        rightAudioArray[i] = AudioMath.ClampShort(rightSig[i] * Volume, short.MinValue, short.MaxValue);
                    }
                    

                    #endregion

                    // Convert from mono input (one channel) to stereo output (two channels)
                    int k = 0;
                    for (int i = 0; i < processedAudio.Length / 2; i++)
                    {
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
                            int mixedValue = destinationShorts[i] + processedAudio[i];
                            

                            // When we mix these together, they might reach below or above the int16 limits, so we need to clip the audio.
                            // A simple Math.Clamp will suffice.
                            destinationShorts[i] = (short)Math.Clamp(mixedValue, short.MinValue, short.MaxValue);
                        }
                    }

                    AudioMath.CopyShortsToBytes(destination, destinationShorts);
                    #endregion
                }
            }

        }

        private void PopulateHRTFs(float elevation, float azimuth, ref double[] leftArray, ref double[] rightArray, double distance = 2000)
        {
            // Use our loaded .mhr HRTF file.
            if (HRTF.HRTF.CurrentHRTFFile != null)
            {
                HRTF.HRTF.CurrentHRTFFile.GenerateHRTFS(elevation, azimuth, ref leftArray, ref rightArray);
            }
            // We don't have a loaded HRTF preset. Fall back to the MIT Kemar data set.
            else
            {
                var taps = HRTF.HRTF.mit_hrtf_availability((int)azimuth, (int)elevation, App.samplingRate);

                if (leftArray.Length != taps)
                    leftArray = new double[taps];

                if (rightArray.Length != taps)
                    rightArray = new double[taps];

                int iAzi = (int)azimuth;
                int iElev = (int)elevation;

                HRTF.HRTF.mit_hrtf_get(ref iAzi, ref iElev, App.samplingRate, 0, ref leftArray, ref rightArray);
            }
        }
    }
}
