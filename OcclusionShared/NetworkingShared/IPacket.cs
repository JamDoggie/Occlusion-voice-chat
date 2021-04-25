using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occlusion.NetworkingShared
{
    public interface IPacket
    {
        /// <summary>
        /// The string identifier this packet will be known by.
        /// This should be unique for EVERY SINGLE packet.
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Takes an incoming message and populates itself based off that message.
        /// </summary>
        /// <param name="message"></param>
        void FromMessage(NetIncomingMessage message);

        /// <summary>
        /// Takes a new outgoing message and populates it.
        /// </summary>
        /// <param name="message"></param>
        void ToMessage(NetOutgoingMessage message);
    }
}
