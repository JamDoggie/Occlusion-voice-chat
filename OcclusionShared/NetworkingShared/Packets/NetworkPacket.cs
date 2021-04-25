using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occlusion.NetworkingShared.Packets
{
    public abstract class NetworkPacket : IPacket
    {
        public string Identifier { get; set; }

        public virtual void FromMessage(NetIncomingMessage message)
        {
            
        }

        public virtual void ToMessage(NetOutgoingMessage message)
        {
            message.Write(PacketManager.GetPacketInternalId(Identifier));
        }
    }
}
