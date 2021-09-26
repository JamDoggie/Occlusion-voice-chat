using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.NetworkingShared.Packets.Attributes
{
    /// <summary>
    /// Any packets with this attribute will have an instance of them created and cached once at runtime.
    /// Then, any incoming packets of this type will use the methods in the pooled instance of the packet object.
    /// This means that if the fields/properties are not properly cleaned up automatically, values can be left behind.
    /// This also means that you should only read and write from this packet sequentially.
    /// 
    /// The benefits of this is performance. Using a pooled packet will essentially eliminate the overhead that would otherwise
    /// be caused by the garbage collector. This is most useful in situations where this packet is being sent a lot in a short amount of time.
    /// </summary>
    public class PooledPacketAttribute : Attribute
    {
    }
}
