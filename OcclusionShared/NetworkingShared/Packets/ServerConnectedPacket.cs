using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using OcclusionVersionControl;

namespace OcclusionShared.NetworkingShared.Packets
{
    /// <summary>
    /// NOTE TO SELF: do not change this packet in any way. I decided to use this packet as the version checking packet which was probably a bad idea, 
    /// however I am too lazy to fix it before this version releases.
    /// </summary>
    [PacketId(4)]
    public class ServerConnectedPacket : NetworkPacket
    {
        public int OcclusionVersion { get; set; } = OcclusionVersionControl.OcclusionVersion.VersionNumber;

        public bool EnableVoiceIconMeterOnClients { get; set; } = true;

        public ServerConnectedPacket()
        {
            Identifier = "ServerConnectedPacket";
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(OcclusionVersion);
            message.Put(EnableVoiceIconMeterOnClients);
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            OcclusionVersion = message.GetInt();
            EnableVoiceIconMeterOnClients = message.GetBool();
        }
    }
}
