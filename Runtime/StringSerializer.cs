using System.IO;

namespace TinySerializer
{
    
    public class StringSerializer : Serializer<string>
    {
        
        public override unsafe void Serialize(Stream stream, string value)
        {
            Serializer<int>.Instance.Serialize(stream, value.Length);
            fixed (char* native = value)
            {
                WriteBytes(stream, (byte*)native, value.Length * sizeof(char));
            }
        }

        public override unsafe string Deserialize(Stream stream)
        {
            var length = Serializer<int>.Instance.Deserialize(stream);
            var s = "".PadRight(length);
            fixed (char* native = s)
            {
                ReadBytes(stream, (byte*)native, length * sizeof(char));
            }
            return s;
        }
    }
}