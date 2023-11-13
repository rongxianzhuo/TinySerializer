using System.IO;

namespace TinySerializer
{
    public class ByteSerializer : Serializer<byte>
    {
        public override void Serialize(Stream stream, byte value)
        {
            stream.WriteByte(value);
        }

        public override byte Deserialize(Stream stream)
        {
            return (byte) stream.ReadByte();
        }
    }
}