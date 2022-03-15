using Occlusion_voice_chat.Opus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Occlusion_Voice_Chat_CrossPlatform.HRTF;
using NWaves.Operations.Convolution;
using NWaves.Signals;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;

namespace Occlusion_Voice_Chat_CrossPlatform.audio
{
    public class HRTFTestSoundEffect : OggOpusSoundEffect
    {
        
        
        private float azimuth = 0.0f;
        public float Azimuth
        {
            get => azimuth;
            set
            {
                lock (QueueLock)
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
                lock(QueueLock)
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

        public bool Muted { get; set; } = true;
        
        public HRTFTestSoundEffect(float volume, string filePath, int channels) : base(filePath, volume, loop: true, 
        decoderChannels: channels)
        {
            
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
        
        public override void MixAudioIntoSpan(ref Span<byte> span)
        {
            if (SpanSize == 0)
            {
                SpanSize = span.Length;
            }

            if (OggInStream == null)
                return;
            
            if (IsPlaying && !Muted)
            {
                lock (QueueLock)
                {
                    if (AudioBuffer.AudioQueued > 0)
                    {
                        // HRTF init
                        int azimuth = (int)Azimuth;
                        int elevation = (int)Elevation;

                        azimuth = Math.Clamp(azimuth, -180, 180);

                        elevation = Math.Clamp(elevation, -40, 90);


            #region Array Initializations
                        if (leftQueueArray == null || leftQueueArray.Length != span.Length)
                        {
                            leftQueueArray = new byte[span.Length / 2]; // Divide by 2 because we're mixing out stereo audio, yet the input microphone audio is currently in mono.
                            rightQueueArray = new byte[span.Length / 2];

                            queuedLeftShortArray = new short[leftQueueArray.Length / 2];
                            queuedRightShortArray = new short[leftQueueArray.Length / 2];
                        }

                        if (processedAudio == null || processedAudio.Length != span.Length / 2)
                        {
                            processedAudio = new short[span.Length / 2];
                        }

                        if (destinationShorts == null || destinationShorts.Length != span.Length / 2)
                        {
                            destinationShorts = new short[span.Length / 2];
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

                        AudioMath.CopyBytesToShorts(destinationShorts, span);
            #endregion


            #region Grab Audio From Queue
                        int amountCut = 0;

                        for (int i = 0; i < span.Length / 2; i++)
                        {
                            if (i < AudioBuffer.BufferLength)
                            {
                                leftQueueArray[i] = AudioBuffer[i - ((int)earDelays.X * 2)];

                                rightQueueArray[i] = AudioBuffer[i - ((int)earDelays.Y * 2)];
                                amountCut++;
                            }
                        }

                        AudioMath.CopyBytesToShorts(queuedLeftShortArray, leftQueueArray);
                        AudioMath.CopyBytesToShorts(queuedRightShortArray, rightQueueArray);


                        // Move everything in the Mic Queue left the amount of bytes that we have mixed into the speakers.
                        AudioBuffer.TryMoveAudioLeft(amountCut);

                        for (int i = 0; i < queuedLeftShortArray.Length; i++)
                        {
                            leftSignal[i] = queuedLeftShortArray[i];
                            rightSignal[i] = queuedRightShortArray[i];
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
                                leftAudioArray[i] = AudioMath.ClampShort(leftSig[i] * Volume, short.MinValue, short
                                .MaxValue);
                            }

                            for (int i = 0; i < rightAudioArray.Length; i++)
                            {
                                rightAudioArray[i] = AudioMath.ClampShort(rightSig[i] * Volume, short.MinValue, short
                                .MaxValue);
                            }
                        }
                        
            #endregion

                        
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

                        AudioMath.CopyShortsToBytes(span, destinationShorts);
            #endregion
                    }
                }
            }
        }
        
        // ReSharper disable once InconsistentNaming
        private void PopulateHRTFs(float elev, float azim, ref double[] leftArray, ref double[] rightArray, float distance = 2000)
        {
            // Use our loaded .mhr HRTF file.
            if (HRTF.HRTF.CurrentHRTFFile != null)
            {
                var delays = HRTF.HRTF.CurrentHRTFFile.GenerateHRTFS(elev, azim, ref leftArray, ref rightArray, distance);

                if (delays != null)
                    earDelays = delays.Value;
            }
            // We don't have a loaded HRTF preset. Fall back to the MIT Kemar data set.
            else
            {
                if (earDelays != Vector2.Zero)
                    earDelays = Vector2.Zero;

                var taps = HRTF.HRTF.mit_hrtf_availability((int)azim, (int)elev, App.samplingRate);

                if (leftArray.Length != taps)
                    leftArray = new double[taps];

                if (rightArray.Length != taps)
                    rightArray = new double[taps];

                int iAzi = (int)azim;
                int iElev = (int)elev;

                HRTF.HRTF.mit_hrtf_get(ref iAzi, ref iElev, App.samplingRate, 0, ref leftArray, ref rightArray);
            }
        }
    }
}
