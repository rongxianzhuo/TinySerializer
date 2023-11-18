using System.IO;

namespace TinySerializer
{
    public class UIntSerializer : Serializer<uint>
    {
        public override void Serialize(Stream stream, uint value)
        {
            stream.WriteByte((byte) value);
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 24));
        }

        public override uint Deserialize(Stream stream)
        {
            var result = (uint)stream.ReadByte();
            result |= (uint)(stream.ReadByte() << 8);
            result |= (uint)(stream.ReadByte() << 16);
            result |= (uint)(stream.ReadByte() << 24);
            return result;
        }
    }
}