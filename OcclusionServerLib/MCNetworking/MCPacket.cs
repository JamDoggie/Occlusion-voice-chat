using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public abstract class MCPacket
    {
        public IByteBuffer buffer = Unpooled.Buffer();

        public virtual void SendMessage(IChannel channel)
        {
            buffer.WriteIntLE(GetInternalID());
        }

        public virtual void FromMessage(IByteBuffer buffer)
        {
            
        }

        public int GetInternalID()
        {
            Console.WriteLine(GetType().Name);
            return MCPacketManager.GetPacketId(GetType());
        }

        public static int GetStringByteLength(string s, Encoding encoding)
        {
            return encoding.GetByteCount(s);
        }
    }
}
