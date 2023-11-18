using System.IO;

namespace TinySerializer
{
    public class BoolSerializer : Serializer<bool>
    {
        public override void Serialize(Stream stream, bool value)
        {
            stream.WriteByte(value ? (byte)1 : (byte)0);
        }

        public override bool Deserialize(Stream stream)
        {
            return stream.ReadByte() == 1;
        }
    }
}