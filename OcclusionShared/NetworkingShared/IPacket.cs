using LiteNetLib;
using LiteNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occlusion.NetworkingShared
{
    public interface IPacket
    {
        /// <summary>
        /// The string identifier this packet will be known by.
        /// This should be unique for EVERY. SINGLE. packet.
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Takes an incoming message and populates itself based off that message.
        /// </summary>
        /// <param name="message"></param>
        void FromMessage(NetPacketReader message);

        /// <summary>
        /// Takes a new outgoing message and writes to it.
        /// </summary>
        /// <param name="message"></param>
        void ToMessage(NetDataWriter message);
    }
}
