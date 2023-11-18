using System.IO;

namespace TinySerializer
{
    public class IntSerializer : Serializer<int>
    {
        public override void Serialize(Stream stream, int value)
        {
            UIntSerializer.Instance.Serialize(stream, (uint) value);
        }

        public override int Deserialize(Stream stream)
        {
            return (int) UIntSerializer.Instance.Deserialize(stream);
        }
    }
}