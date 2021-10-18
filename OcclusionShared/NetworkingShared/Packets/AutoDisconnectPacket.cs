using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class AutoDisconnectPacket : NetworkPacket
    {
        public bool ShowWarning { get; set; } = false;

        public float SecondsTillDisconnect { get; set; } = 5;

        public AutoDisconnectPacket()
        {
            Identifier = "AutoDisconnectPacket";
#if SERVER
            SecondsTillDisconnect = OcclusionServerLib.Server.IdleKickLength;
#endif
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);
            message.Put(ShowWarning);
            message.Put(SecondsTillDisconnect);
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);
            ShowWarning = message.GetBool();
            SecondsTillDisconnect = message.GetFloat();
        }
    }
}
