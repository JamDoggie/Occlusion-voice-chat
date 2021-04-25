using Lidgren.Network;
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

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);
            message.Write(UUID);
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);
            UUID = message.ReadString();
        }
    }
}
