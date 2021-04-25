using Lidgren.Network;
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

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);

            int dataLength = message.ReadInt32();
            VoiceData = new byte[dataLength];
            for (int i = 0; i < dataLength; i++)
            {
                VoiceData[i] = message.ReadByte();
            }
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);

            message.Write(VoiceData.Length);

            for (int i = 0; i < VoiceData.Length; i++)
            {
                message.Write(VoiceData[i]);
            }
        }
    }
}
