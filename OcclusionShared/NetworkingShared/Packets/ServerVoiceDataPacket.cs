using LiteNetLib;
using LiteNetLib.Utils;
using OcclusionShared.NetworkingShared.Packets.Attributes;
using PestControlShared.NetworkingShared.Packets.Attributes;

namespace Occlusion.NetworkingShared.Packets
{
    [PacketId(1), PooledPacket]
    public class ServerVoiceDataPacket : NetworkPacket
    {
        public byte[] VoiceData { get; set; }

        public float Volume { get; set; }

        public float Pan { get; set; }

        public float HRTFAzimuth { get; set; }

        public float HRTFElevation { get; set; }

        public int ID { get; set; } = -1;

        public ServerVoiceDataPacket()
        {
            Identifier = "ServerVoiceDataPacket";
        }

        public override void FromMessage(NetPacketReader message)
        {
            base.FromMessage(message);

            VoiceData = message.GetBytesWithLength();

            Volume = message.GetFloat();

            Pan = message.GetFloat();

            HRTFAzimuth = message.GetFloat();

            HRTFElevation = message.GetFloat();

            ID = message.GetInt();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            message.PutBytesWithLength(VoiceData);

            message.Put(Volume);

            message.Put(Pan);

            message.Put(HRTFAzimuth);

            message.Put(HRTFElevation);

            message.Put(ID);
        }
    }
}
