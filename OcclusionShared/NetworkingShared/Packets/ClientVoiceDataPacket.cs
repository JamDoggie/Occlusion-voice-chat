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
                VoiceData = message.GetBytesWithLength();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            if (VoiceData != null)
                message.PutBytesWithLength(VoiceData);
            else
            {
                message.Put(2);
                for (int i = 0; i < 2; i++)
                    message.Put((byte)0);
            }
        }
    }
}
