using LiteNetLib;
using LiteNetLib.Utils;
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

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);

            int count = message.GetInt();

            for(int i = 0; i < count; i++)
            {
                int id = message.GetInt();
                string uuid = message.GetString();
                idsToAdd.Add(new KeyValuePair<int, string>(id, uuid));
            }
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            message.Put(idsToAdd.Count);

            foreach(KeyValuePair<int, string> pair in idsToAdd)
            {
                message.Put(pair.Key);
                message.Put(pair.Value);
            }
        }
    }
}
