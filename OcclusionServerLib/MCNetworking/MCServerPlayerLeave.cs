using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public class MCServerPlayerLeave : MCPacket
    {
        public int Code { get; set; } = -1;

        public string UUID { get; set; }

        public override void FromMessage(IByteBuffer buffer)
        {
            base.FromMessage(buffer);

            // Verification ID
            Code = buffer.ReadIntLE();

            // Minecraft UUId
            var uuidLength = buffer.ReadIntLE();

            UUID = buffer.ReadString(uuidLength, Encoding.UTF8);
        }
    }
}
