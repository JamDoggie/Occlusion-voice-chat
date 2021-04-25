using System;
using System.Collections.Generic;
using System.Text;

namespace PestControlShared.NetworkingShared.Packets.Attributes
{
    /// <summary>
    /// This attribute forces this packet to be registered with the specified internal id.
    /// This is important for packets that tell the client/server things like version, ping, or anything that should be communicated
    /// no matter what version the client and server are running.
    /// Otherwise, internal packet ids are magic numbers and should be treated carefully.
    /// If an id is defined that another packet has, there is no safety checking so they will have duplicated ids and that will break things.
    /// These "forced ids" are defined before any automatic ids are generated however, so you should only worry about clashing between other forced ids.
    /// </summary>
    public class PacketIdAttribute : Attribute
    {
        public int id { get; set; }
        
        public PacketIdAttribute(int id)
        {
            this.id = id;
        }
    }
}
