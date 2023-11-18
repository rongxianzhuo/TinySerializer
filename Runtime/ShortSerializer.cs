using System.IO;

namespace TinySerializer
{
    public class ShortSerializer : Serializer<short>
    {
        
        public override void Serialize(Stream stream, short value)
        {
            UShortSerializer.Instance.Serialize(stream, (ushort) value);
        }

        public override short Deserialize(Stream stream)
        {
            return (short) UShortSerializer.Instance.Deserialize(stream);
        }
    }
}