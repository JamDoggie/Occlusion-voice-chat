using PestControlShared.NetworkingShared.Packets.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Occlusion.NetworkingShared
{
    public static class PacketManager
    {
        public static Dictionary<string, Type> PacketIds { get; set; } = new Dictionary<string, Type>();

        /// <summary>
        /// These are the internal ids used when sending these packets over the network. The point of sending an int instead of a string is mainly optimization, so we're not sending 
        /// too many bytes over the network.
        /// </summary>
        public static Dictionary<int, string> PacketInternalIds { get; set; } = new Dictionary<int, string>();

        private static int _PacketIdIterator = 0;

        /// <summary>
        /// Uses reflection to store all packet types in a dictionary with their identifier as the key.
        /// </summary>
        public static void CollectPacketTypes()
        {
            PacketIds.Clear();

            Assembly[] assemblies = new Assembly[1];
            assemblies[0] = Assembly.GetExecutingAssembly();

            // Get all packets in the current realm using reflection and cache them
            var packetTypes = (
                    from domainAssembly in assemblies
                    from assemblyType in domainAssembly.GetTypes()
                    where typeof(IPacket).IsAssignableFrom(assemblyType)
                    select assemblyType).ToArray();

            List<string> predefinedIds = new List<string>();

            // Define pre-forced internal ids first to avoid clashing with automatic ids.
            foreach (Type t in packetTypes)
            {
                if (t != typeof(IPacket))
                {
                    if (Attribute.GetCustomAttributes(t).Length > 0)
                    {
                        foreach(Attribute attrib in Attribute.GetCustomAttributes(t))
                        {
                            if (attrib is PacketIdAttribute)
                            {
                                var dummyObj = Activator.CreateInstance(t);

                                IPacket packetObj;
                                if ((packetObj = dummyObj as IPacket) != null)
                                {
                                    PacketIds[packetObj.Identifier] = t;
                                    PacketInternalIds[((PacketIdAttribute)attrib).id] = packetObj.Identifier;

                                    predefinedIds.Add(packetObj.Identifier);

                                    Trace.WriteLine($"PACKET TYPE REGISTERED: {packetObj.Identifier} ID: {((PacketIdAttribute)attrib).id}");
                                    Console.WriteLine($"PACKET TYPE REGISTERED: {packetObj.Identifier} ID: {((PacketIdAttribute)attrib).id}");
                                }
                            }
                        }
                    }
                }
            }

            IOrderedEnumerable<Type> sortedPackets = packetTypes.OrderBy(x => x.FullName);
            packetTypes = sortedPackets.ToArray();
            foreach (Type t in packetTypes)
            {
                if (t != typeof(IPacket) && !t.IsAbstract)
                {
                    var dummyObj = Activator.CreateInstance(t);

                    IPacket packetObj;
                    if ((packetObj = dummyObj as IPacket) != null && !predefinedIds.Contains(packetObj.Identifier))
                    {
                        // Iterate the packet id counter if we need to.
                        // This should skip the iterator past any pre-defined forced ids. See the PacketIdAttribute class's summary for more information.
                        while (PacketInternalIds.TryGetValue(_PacketIdIterator, out string _))
                        {
                            _PacketIdIterator++;
                        }

                        PacketIds[packetObj.Identifier] = t;
                        PacketInternalIds[_PacketIdIterator] = packetObj.Identifier;




                        Trace.WriteLine($"PACKET TYPE REGISTERED: {packetObj.Identifier} ID: {_PacketIdIterator}");
                        Console.WriteLine($"PACKET TYPE REGISTERED: {packetObj.Identifier} ID: {_PacketIdIterator}");
                    }
                }
            }
        }

        public static int GetPacketInternalId(string identifier)
        {
            foreach(KeyValuePair<int, string> pair in PacketInternalIds)
            {
                if (pair.Value == identifier)
                {
                    return pair.Key;
                }
            }

            return -1;
        }
    }
}
