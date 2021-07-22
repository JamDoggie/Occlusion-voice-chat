using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    [PacketId(2)]
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

            VoiceData = message.GetBytesWithLength();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            message.PutBytesWithLength(VoiceData);
        }
    }
}
