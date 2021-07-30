using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerBitrateChangePacket : NetworkPacket
    {
        public int NewBitrate { get; set; } = 64; // Kbps

        public ServerBitrateChangePacket()
        {
            Identifier = "ServerBitrateChangePacket";
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            NewBitrate = message.GetInt();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(NewBitrate);
        }
    }
}
