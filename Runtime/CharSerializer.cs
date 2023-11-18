using System.IO;

namespace TinySerializer
{
    public class CharSerializer : Serializer<char>
    {
        
        public override void Serialize(Stream stream, char value)
        {
            UShortSerializer.Instance.Serialize(stream, (ushort) value);
        }

        public override char Deserialize(Stream stream)
        {
            return (char) UShortSerializer.Instance.Deserialize(stream);
        }
    }
}