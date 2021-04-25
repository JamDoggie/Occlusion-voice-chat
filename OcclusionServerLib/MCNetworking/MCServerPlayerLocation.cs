using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public class MCServerPlayerLocation : MCPacket
    {
        public int VerificationCode { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

        public float Pitch { get; set; }

        public float Yaw { get; set; }

        public string World { get; set; }

        public bool IsSpectator { get; set; } = false;
        public override void FromMessage(IByteBuffer buffer)
        {
            base.FromMessage(buffer);

            VerificationCode = buffer.ReadIntLE();

            PosX = buffer.ReadFloatLE();

            PosY = buffer.ReadFloatLE();

            PosZ = buffer.ReadFloatLE();

            Pitch = buffer.ReadFloatLE();

            Yaw = buffer.ReadFloatLE();
            
            int stringLength = buffer.ReadIntLE();
            World = buffer.ReadString(stringLength, Encoding.UTF8);

            IsSpectator = buffer.ReadBoolean();
        }

        /// <summary>
        /// Shouldn't need to send this message, so this will most likely never be used.
        /// </summary>
        /// <param name="channel"></param>
        public override void SendMessage(IChannel channel)
        {
            base.SendMessage(channel);

            buffer.WriteIntLE(VerificationCode);

            buffer.WriteFloatLE(PosX);

            buffer.WriteFloatLE(PosY);

            buffer.WriteFloatLE(PosZ);

            buffer.WriteFloatLE(Pitch);

            buffer.WriteFloatLE(Yaw);

            buffer.WriteIntLE(GetStringByteLength(World, Encoding.UTF8));

            buffer.WriteString(World, Encoding.UTF8);

            buffer.WriteBoolean(IsSpectator);
        }
    }
}
