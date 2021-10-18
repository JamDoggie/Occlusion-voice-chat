using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using OcclusionShared.NetworkingShared.Packets.Attributes;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    [PacketId(2), PooledPacket]
    public class ClientVoiceDataPacket : NetworkPacket
    {
        public byte[] VoiceData { get; set; }

        public ClientVoiceDataPacket()
        {
            Identifier = "ClientVoiceDataPacket";
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);

            if (!message.IsNull && message.AvailableBytes > 0 && !message.EndOfData)
            {
                int length = message.GetInt();

                if (message.AvailableBytes < length)
                    return; // Litenetlib sometimes randomly seems to just cut this packet off, or corrupt it or something(??). IDK anyway this should fix it.

                if (VoiceData == null || VoiceData.Length != length)
                {
                    VoiceData = new byte[length];
                }

                for(int i = 0; i < VoiceData.Length; i++)
                {
                    VoiceData[i] = message.GetByte();
                }
            }
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            if (VoiceData == null)
            {
                VoiceData = new byte[2];
                VoiceData[0] = 0;
                VoiceData[1] = 0;
            }

            message.Put(VoiceData.Length);
            for(int i = 0; i < VoiceData.Length; i++)
            {
                message.Put(VoiceData[i]);
            }
        }
    }
}
