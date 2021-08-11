using Concentus.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.Opus
{
    public interface ICodec
    {
        void SetBitrate(int bitrate);
        void SetComplexity(int complexity);
        void SetPacketLoss(int loss);
        void SetApplication(OpusApplication application);
        void SetFrameSize(double frameSize);
        void SetVBRMode(bool vbr, bool constrained);
        byte[] Compress(AudioChunk? input);
        AudioChunk Decompress(byte[] input);
    }
}