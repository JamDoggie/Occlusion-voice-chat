using Lidgren.Network;
using Occlusion.NetworkingShared.Packets;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    [PacketId(3)]
    public class ClientVerificationPacket : NetworkPacket
    {
        public int VerificationCode { get; set; } = -1;

        public ClientVerificationPacket()
        {
            Identifier = "ClientVerificationPacket";
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);
            VerificationCode = message.ReadInt32();
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);
            message.Write(VerificationCode);
        }
    }
}
