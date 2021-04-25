using Lidgren.Network;
using Occlusion.NetworkingShared.Packets;
using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    [PacketId(0)]
    public class ServerUserConnectedPacket : NetworkPacket
    {
        public List<KeyValuePair<int, string>> idsToAdd { get; set; } = new List<KeyValuePair<int, string>>();

        public ServerUserConnectedPacket()
        {
            Identifier = "ServerUserConnectedPacket";
        }

        public override void FromMessage(NetIncomingMessage message)
        {
            base.FromMessage(message);

            int count = message.ReadInt32();

            for(int i = 0; i < count; i++)
            {
                int id = message.ReadInt32();
                string uuid = message.ReadString();
                idsToAdd.Add(new KeyValuePair<int, string>(id, uuid));
            }
        }

        public override void ToMessage(NetOutgoingMessage message)
        {
            base.ToMessage(message);

            message.Write(idsToAdd.Count);

            foreach(KeyValuePair<int, string> pair in idsToAdd)
            {
                message.Write(pair.Key);
                message.Write(pair.Value);
            }
        }
    }
}
