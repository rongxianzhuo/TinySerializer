using System;
using System.IO;

namespace TinySerializer
{
    public class FloatSerializer : Serializer<float>
    {
        
        public override void Serialize(Stream stream, float value)
        {
            IntSerializer.Instance.Serialize(stream, BitConverter.SingleToInt32Bits(value));
        }

        public override float Deserialize(Stream stream)
        {
            return BitConverter.Int32BitsToSingle(IntSerializer.Instance.Deserialize(stream));
        }
    }
}