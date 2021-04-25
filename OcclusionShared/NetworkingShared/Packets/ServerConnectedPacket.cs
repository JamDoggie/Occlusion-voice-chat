using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerConnectedPacket : NetworkPacket
    {
        public ServerConnectedPacket()
        {
            Identifier = "ServerConnectedPacket";
        }
    }
}
