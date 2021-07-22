using LiteNetLib;
using LiteNetLib.Utils;
using Occlusion.NetworkingShared.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets
{
    public class ServerValidationRejected : NetworkPacket
    {
        public ServerValidationRejected()
        {
            Identifier = "ServerValidationRejected";
        }
    }
}
