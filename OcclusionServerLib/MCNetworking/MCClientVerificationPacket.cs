using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public class MCClientVerificationPacket : MCPacket
    {
        public int Code { get; set; }

        public override void SendMessage(IChannel channel)
        {
            base.SendMessage(channel);

            buffer.WriteIntLE(Code);
        }

        public override void FromMessage(IByteBuffer buffer)
        {
            base.FromMessage(buffer);
            Code = buffer.ReadIntLE();
        }
    }
}
