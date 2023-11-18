using System.IO;

namespace TinySerializer
{
    public class UShortSerializer : Serializer<ushort>
    {
        
        public override void Serialize(Stream stream, ushort value)
        {
            stream.WriteByte((byte) value);
            stream.WriteByte((byte)(value >> 8));
        }

        public override ushort Deserialize(Stream stream)
        {
            var result = (ushort)stream.ReadByte();
            result |= (ushort)(stream.ReadByte() << 8);
            return result;
        }
    }
}