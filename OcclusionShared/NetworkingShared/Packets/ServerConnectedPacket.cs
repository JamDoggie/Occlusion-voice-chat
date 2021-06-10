using Lidgren.Network;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerConnectedPacket : NetworkPacket
    {
        public bool EnableVoiceIconMeterOnClients { get; set; } = true;

        public ServerConnectedPacket()
        {
            Identifier = "ServerConnectedPacket";
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);
            message.Write(EnableVoiceIconMeterOnClients);
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);
            EnableVoiceIconMeterOnClients = message.ReadBoolean();
        }
    }
}
