#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Occlusion_voice_chat.Opus
{
    using Concentus;
    using Concentus.Common.CPlusPlus;
    using Concentus.Enums;
    using Concentus.Structs;
    using Occlusion_voice_chat.Opus;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class OpusCodec : ICodec
    {
        private const string OPUS_TARGET_DLL = "opus";

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr opus_encoder_create(int Fs, int channels, int application, out IntPtr error);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void opus_encoder_destroy(IntPtr encoder);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int opus_encode(IntPtr st, byte[] pcm, int frame_size, IntPtr data, int max_data_bytes);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int opus_encoder_ctl(IntPtr st, int request, int value);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr opus_decoder_create(int Fs, int channels, out IntPtr error);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void opus_decoder_destroy(IntPtr decoder);

        [DllImport(OPUS_TARGET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int opus_decode(IntPtr st, byte[] data, int len, IntPtr pcm, int frame_size, int decode_fec);

        private const int OPUS_SET_BITRATE_REQUEST = 4002;
        private const int OPUS_SET_COMPLEXITY_REQUEST = 4010;
        private const int OPUS_SET_PACKET_LOSS_PERC_REQUEST = 4014;
        private const int OPUS_SET_VBR_REQUEST = 4006;
        private const int OPUS_SET_VBR_CONSTRAINT_REQUEST = 4020;
        private const int OPUS_SET_INBAND_FEC_REQUEST = 4012;
        private const int OPUS_SET_DTX_REQUEST = 4016;
        private const int OPUS_SET_FORCE_MODE_REQUEST = 11002;

        private const int OPUS_MODE_SILK_ONLY = 1000;

        private const int OPUS_APPLICATION_VOIP = 2048;
        private const int OPUS_APPLICATION_AUDIO = 2049;

        private int _bitrate = 64;
        private int _complexity = 2;
        private double _frameSize = 20;
        private int _packetLoss = 0;
        private int _application = OPUS_APPLICATION_VOIP;
        private bool _vbr = false;
        private bool _cvbr = false;

        private BasicBufferShort _incomingSamples = new BasicBufferShort(48000);

        private IntPtr _encoder = IntPtr.Zero;
        private IntPtr _decoder = IntPtr.Zero;

        private byte[] scratchBuffer = new byte[10000];

        public OpusCodec()
        {
            IntPtr error;
            _encoder = opus_encoder_create(48000, 1, OPUS_APPLICATION_VOIP, out error);
            if ((int)error != 0)
            {
                throw new ApplicationException("Could not initialize Opus encoder");
            }

            SetBitrate(_bitrate);
            SetComplexity(_complexity);
            SetVBRMode(_vbr, _cvbr);

            _decoder = opus_decoder_create(48000, 1, out error);
            if ((int)error != 0)
            {
                throw new ApplicationException("Could not initialize Opus decoder");
            }
        }

        public OpusCodec(int channels)
        {
            IntPtr error;
            _encoder = opus_encoder_create(48000, channels, OPUS_APPLICATION_VOIP, out error);
            if ((int)error != 0)
            {
                throw new ApplicationException("Could not initialize Opus encoder");
            }

            SetBitrate(_bitrate);
            SetComplexity(_complexity);
            SetVBRMode(_vbr, _cvbr);

            _decoder = opus_decoder_create(48000, channels, out error);
            if ((int)error != 0)
            {
                throw new ApplicationException("Could not initialize Opus decoder");
            }
        }

        public void SetBitrate(int bitrate)
        {
            _bitrate = bitrate;
            opus_encoder_ctl(_encoder, OPUS_SET_BITRATE_REQUEST, _bitrate * 1024);
        }

        public void SetComplexity(int complexity)
        {
            _complexity = complexity;
            opus_encoder_ctl(_encoder, OPUS_SET_COMPLEXITY_REQUEST, _complexity);
        }

        public void SetFrameSize(double frameSize)
        {
            _frameSize = frameSize;
        }

        public void SetPacketLoss(int loss)
        {
            _packetLoss = loss;
            if (loss > 0)
            {
                opus_encoder_ctl(_encoder, OpusControl.OPUS_SET_PACKET_LOSS_PERC_REQUEST, _packetLoss);
                opus_encoder_ctl(_encoder, OpusControl.OPUS_SET_INBAND_FEC_REQUEST, 1);
            }
            else
            {
                opus_encoder_ctl(_encoder, OpusControl.OPUS_SET_PACKET_LOSS_PERC_REQUEST, 0);
                opus_encoder_ctl(_encoder, OpusControl.OPUS_SET_INBAND_FEC_REQUEST, 0);
            }
        }

        public void SetApplication(OpusApplication application)
        {
            _application = (int)application;
            opus_encoder_ctl(_encoder, (int)OpusControl.OPUS_SET_APPLICATION_REQUEST, _application);
        }

        public void SetVBRMode(bool vbr, bool constrained)
        {
            _vbr = vbr;
            _cvbr = constrained;
            opus_encoder_ctl(_encoder, (int)OpusControl.OPUS_SET_VBR_REQUEST, vbr ? 1 : 0);
            opus_encoder_ctl(_encoder, (int)OpusControl.OPUS_SET_VBR_CONSTRAINT_REQUEST, constrained ? 1 : 0);
        }

        private int GetFrameSize()
        {
            return (int)(48000 * _frameSize / 1000);
        }

        public byte[] Compress(AudioChunk? input)
        {
            int frameSize = GetFrameSize();

            if (input != null)
            {
                short[] newData = input?.Data;
                _incomingSamples.Write(newData);
            }
            else
            {
                // If input is null, assume we are at end of stream and pad the output with zeroes
                int paddingNeeded = _incomingSamples.Available() % frameSize;
                if (paddingNeeded > 0)
                {
                    _incomingSamples.Write(new short[paddingNeeded]);
                }
            }

            int outCursor = 0;

            if (_incomingSamples.Available() >= frameSize)
            {
                unsafe
                {
                    fixed (byte* benc = scratchBuffer)
                    {
                        short[] nextFrameData = _incomingSamples.Read(frameSize);
                        byte[] nextFrameBytes = AudioMath.ShortsToBytes(nextFrameData);
                        IntPtr encodedPtr = new IntPtr(benc);
                        int thisPacketSize = opus_encode(_encoder, nextFrameBytes, frameSize, encodedPtr, scratchBuffer.Length);
                        outCursor += thisPacketSize;
                    }
                }
            }

            /*if (outCursor > 0)
            {
                _statistics.EncodeSpeed = _frameSize / ((double)_timer.ElapsedTicks / Stopwatch.Frequency * 1000);
            }*/

            byte[] finalOutput = new byte[outCursor];
            Array.Copy(scratchBuffer, 0, finalOutput, 0, outCursor);
            return finalOutput;
        }

        public AudioChunk Decompress(byte[] inputPacket)
        {
            int frameSize = GetFrameSize();

            short[] outputBuffer = new short[frameSize];


            // Decode the audio.
            unsafe
            {
                fixed (short* bdec = outputBuffer)
                {
                    IntPtr decodedPtr = new IntPtr((byte*)(bdec));
                    int thisFrameSize = opus_decode(_decoder, inputPacket, inputPacket.Length, decodedPtr, frameSize, 0);
                }
            }


            short[] finalOutput = new short[frameSize];
            Array.Copy(outputBuffer, finalOutput, finalOutput.Length);

            // Update statistics
            /*_statistics.Bitrate = inputPacket.Length * 8 * 48000 / 1024 / frameSize;
            OpusMode curMode = OpusPacketInfo.GetEncoderMode(inputPacket, 0);
            if (curMode == OpusMode.MODE_CELT_ONLY)
            {
                _statistics.Mode = "CELT";
            }
            else if (curMode == OpusMode.MODE_HYBRID)
            {
                _statistics.Mode = "Hybrid";
            }
            else if (curMode == OpusMode.MODE_SILK_ONLY)
            {
                _statistics.Mode = "SILK";
            }
            else
            {
                _statistics.Mode = "Unknown";
            }
            _statistics.DecodeSpeed = _frameSize / ((double)_timer.ElapsedTicks / Stopwatch.Frequency * 1000);
            */
            return new AudioChunk(finalOutput, 48000);
        }
    }
}