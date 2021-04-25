using Lidgren.Network;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerDisconnectPacket : NetworkPacket
    {
        public string DisconnectMessage { get; set; }

        public ServerDisconnectPacket()
        {
            Identifier = "ServerDisconnectPacket";
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);
            message.Write(DisconnectMessage);
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);
            DisconnectMessage = message.ReadString();
        }
    }
}
