using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerUserLeftPacket : NetworkPacket
    {
        public string UUID { get; set; }

        public ServerUserLeftPacket()
        {
            Identifier = "ServerUserLeftPacket";
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(UUID);
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            UUID = message.GetString();
        }
    }
}
