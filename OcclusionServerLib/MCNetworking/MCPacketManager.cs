using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.MCNetworking
{
    public static class MCPacketManager
    {
        public static Dictionary<int, Type> RegisteredPackets = new Dictionary<int, Type>();


        public static void RegisterPackets()
        {
            // The manual defining of packet ids is on purpose.
            // Since we're defining packets between different platforms, any automatic packet ID registering is probably not gonna be consistent.
            RegisterPacket<MCClientVerificationPacket>(0);
            RegisterPacket<MCServerVerificationPacket>(1);
            RegisterPacket<MCServerPlayerLocation>(2);
            RegisterPacket<MCServerPlayerLeave>(3);
        }

        public static void RegisterPacket<T>(int id)
        {
            RegisteredPackets[id] = typeof(T);
        }

        public static int GetPacketId(Type type)
        {
            foreach(KeyValuePair<int, Type> pair in RegisteredPackets)
            {
                if (pair.Value == type)
                {
                    return pair.Key;
                }
            }

            // Throw an exception if we couldn't find it
            PacketIDNotFoundException exception = new PacketIDNotFoundException($"Packet ID was not found for type \"{type.FullName}\"");
            throw exception;
        }

        public static Type GetPacketTypeById(int id)
        {
            foreach (KeyValuePair<int, Type> pair in RegisteredPackets)
            {
                if (pair.Key == id)
                {
                    return pair.Value;
                }
            }

            // Throw an exception if we couldn't find it
            PacketIDNotFoundException exception = new PacketIDNotFoundException($"Packet ID {id} was not found.");
            throw exception;
        }
    }

    public class PacketIDNotFoundException : Exception
    {
        public PacketIDNotFoundException(string message) : base(message) { }
    }
}
