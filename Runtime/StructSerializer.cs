using System.IO;

namespace TinySerializer
{
    public class StructSerializer<T> : Serializer<T> where T : unmanaged
    {
        
        public override unsafe void Serialize(Stream stream, T value)
        {
            var ptr = (byte*)&value;
            var count = sizeof(T);
            WriteBytes(stream, ptr, count);
        }

        public override unsafe T Deserialize(Stream stream)
        {
            T result = default;
            var ptr = (byte*)&result;
            var count = sizeof(T);
            ReadBytes(stream, ptr, count);
            return result;
        }
    }
}