using Lidgren.Network;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occlusion.NetworkingShared.Packets
{
    [PacketId(1)]
    public class ServerVoiceDataPacket : NetworkPacket
    {
        public byte[] VoiceData { get; set; }

        public float Volume { get; set; }

        public float Pan { get; set; }

        public int ID { get; set; } = -1;

        public ServerVoiceDataPacket()
        {
            Identifier = "ServerVoiceDataPacket";
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);

            int dataLength = message.ReadInt32();
            VoiceData = new byte[dataLength];
            for(int i = 0; i < dataLength; i++)
            {
                VoiceData[i] = message.ReadByte();
            }

            Volume = message.ReadFloat();

            Pan = message.ReadFloat();

            ID = message.ReadInt32();
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);

            message.Write(VoiceData.Length);

            for(int i = 0; i < VoiceData.Length; i++)
            {
                message.Write(VoiceData[i]);
            }


            message.Write(Volume);

            message.Write(Pan);

            message.Write(ID);
        }
    }
}
