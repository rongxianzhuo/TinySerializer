using System.IO;
using System.Runtime.CompilerServices;

namespace TinySerializer
{
    
    public class StringSerializer : Serializer<string>
    {
        
        public override unsafe void Serialize(Stream stream, string value)
        {
            SerializationUtility.Serialize(stream, value.Length);
            fixed (char* native = value)
            {
                WriteBytes(stream, (byte*)native, value.Length * sizeof(char));
            }
        }

        public override unsafe string Deserialize(Stream stream)
        {
            var length = SerializationUtility.Deserialize<int>(stream);
            var s = "".PadRight(length);
            fixed (char* native = s)
            {
                ReadBytes(stream, (byte*)native, length * sizeof(char));
            }
            return s;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetWriteSize(string s)
        {
            return sizeof(int) + s.Length * sizeof(char);
        }
    }
}