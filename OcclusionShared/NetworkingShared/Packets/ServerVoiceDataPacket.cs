using LiteNetLib;
using LiteNetLib.Utils;
using PestControlShared.NetworkingShared.Packets.Attributes;

namespace Occlusion.NetworkingShared.Packets
{
    [PacketId(1)]
    public class ServerVoiceDataPacket : NetworkPacket
    {
        public byte[] VoiceData { get; set; }

        public float Volume { get; set; }

        public float Pan { get; set; }

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

            ID = message.GetInt();
        }

        public override void ToMessage(NetDataWriter message)
        {
            base.ToMessage(message);

            message.PutBytesWithLength(VoiceData);


            message.Put(Volume);

            message.Put(Pan);

            message.Put(ID);
        }
    }
}
