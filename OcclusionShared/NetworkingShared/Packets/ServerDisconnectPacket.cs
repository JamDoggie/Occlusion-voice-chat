using LiteNetLib;
using LiteNetLib.Utils;
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

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(DisconnectMessage);
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            DisconnectMessage = message.GetString();
        }
    }
}
