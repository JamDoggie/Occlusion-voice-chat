using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    /// <summary>
    /// Sends information including the player's occlusion code, and the version their client is running.
    /// NOTE: This packet should probably not be changed in the future, to ensure that all client and server versions can communicate with it.
    /// </summary>
    [PacketId(3)]
    public class ClientVerificationPacket : NetworkPacket
    {
        public int VerificationCode { get; set; } = -1;

        public ClientVerificationPacket()
        {
            Identifier = "ClientVerificationPacket";
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            VerificationCode = message.GetInt();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(VerificationCode);
        }
    }
}
