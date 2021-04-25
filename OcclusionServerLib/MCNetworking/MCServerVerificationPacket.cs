using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public class MCServerVerificationPacket : MCPacket
    {
        public int Code { get; set; }

        public bool Verified { get; set; }

        public string UUID { get; set; }

        public override void FromMessage(IByteBuffer buffer)
        {
            base.FromMessage(buffer);
            Code = buffer.ReadIntLE();
            int uuidLength = buffer.ReadIntLE();
            UUID = buffer.ReadString(uuidLength, Encoding.UTF8);
            Verified = buffer.ReadBoolean();
        }

        public override void SendMessage(IChannel channel)
        {
            base.SendMessage(channel);


        }
    }
}
