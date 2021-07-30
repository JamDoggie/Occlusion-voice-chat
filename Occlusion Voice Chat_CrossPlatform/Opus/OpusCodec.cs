using Concentus.Enums;
using Concentus.Structs;
using Occlusion_Voice_Chat_CrossPlatform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.Opus
{
    public class OpusCodec : ICodec
    {
        private int _bitrate = 64;
        private int _complexity = 1;
        private double _frameSize = 20;
        private int _packetLoss = 0;
        private bool _vbr = false;
        private bool _cvbr = false;
        private OpusApplication _application = OpusApplication.VOIP;

        private BasicBufferShort _incomingSamples = new BasicBufferShort(App.samplingRate);

        private OpusEncoder _encoder;
        private OpusDecoder _decoder;

        private byte[] scratchBuffer = new byte[10000];

        public int Bitrate
        {
            get => _bitrate;
            
            set
            {
                _encoder.Bitrate = (value * 1024);
                _bitrate = value;
            }
        }

        public OpusCodec()
        {
            _encoder = OpusEncoder.Create(App.samplingRate, 1, OpusApplication.VOIP);
            
            SetBitrate(_bitrate);
            SetComplexity(_complexity);
            SetVBRMode(_vbr, _cvbr);
            _decoder = OpusDecoder.Create(App.samplingRate, 1);
        }

        public void SetBitrate(int bitrate)
        {
            _bitrate = bitrate;
            _encoder.Bitrate = (_bitrate * 1024);
        }

        public void SetComplexity(int complexity)
        {
            _complexity = complexity;
            _encoder.Complexity = (_complexity);
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
                _encoder.PacketLossPercent = _packetLoss;
                _encoder.UseInbandFEC = true;
            }
            else
            {
                _encoder.PacketLossPercent = 0;
                _encoder.UseInbandFEC = false;
            }
        }

        public void SetApplication(OpusApplication application)
        {
            _application = application;
            _encoder.Application = _application;
        }

        public void SetVBRMode(bool vbr, bool constrained)
        {
            _vbr = vbr;
            _cvbr = constrained;
            _encoder.UseVBR = vbr;
            _encoder.UseConstrainedVBR = constrained;
        }

        private int GetFrameSize()
        {
            return (int)(App.samplingRate * _frameSize / 1000);
        }


        public byte[] Compress(AudioChunk input)
        {
            int frameSize = GetFrameSize();

            //if (input != null)
            //{
                short[] newData = input.Data;
                _incomingSamples.Write(newData);
            //}
            //else
            //{
            //    // If input is null, assume we are at end of stream and pad the output with zeroes
            //    int paddingNeeded = _incomingSamples.Available() % frameSize;
            //    if (paddingNeeded > 0)
            //    {
            //        _incomingSamples.Write(new short[paddingNeeded]);
            //    }
            //}

            int outCursor = 0;

            if (_incomingSamples.Available() >= frameSize)
            {
                short[] nextFrameData = _incomingSamples.Read(frameSize);
                int thisPacketSize = _encoder.Encode(nextFrameData, 0, frameSize, scratchBuffer, outCursor, scratchBuffer.Length);
                outCursor += thisPacketSize;
            }

            byte[] finalOutput = new byte[outCursor];
            Array.Copy(scratchBuffer, 0, finalOutput, 0, outCursor);
            return finalOutput;
        }

        public AudioChunk Decompress(byte[] inputPacket)
        {
            int frameSize = GetFrameSize();

            short[] outputBuffer = new short[frameSize];

            bool lostPacket = new Random().Next(0, 100) < _packetLoss;
            if (!lostPacket)
            {
                // Normal decoding
                int thisFrameSize = _decoder.Decode(inputPacket, 0, inputPacket.Length, outputBuffer, 0, frameSize, false);
            }
            else
            {
                // packet loss path
                int thisFrameSize = _decoder.Decode(null, 0, 0, outputBuffer, 0, frameSize, true);
            }

            short[] finalOutput = new short[frameSize];
            Array.Copy(outputBuffer, finalOutput, finalOutput.Length);

            return new AudioChunk(finalOutput, App.samplingRate);
        }
    }
}
