using LiteNetLib;
using LiteNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occlusion.NetworkingShared.Packets
{
    public abstract class NetworkPacket : IPacket
    {
        public string Identifier { get; set; }

        public virtual void FromMessage(NetPacketReader message)
        {
            
        }

        public virtual void ToMessage(NetDataWriter message)
        {
            message.Put(PacketManager.GetPacketInternalId(Identifier));
        }
    }
}
