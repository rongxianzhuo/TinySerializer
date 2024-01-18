using System.IO;
using UnityEngine;

namespace TinySerializer
{
    public abstract class Serializer<T>
    {

        public static Serializer<T> Instance;

        public abstract void Serialize(Stream stream, T value);

        public abstract T Deserialize(Stream stream);
        
        static Serializer()
        {
            Serializer<bool>.Instance = new BoolSerializer();
            Serializer<byte>.Instance = new ByteSerializer();
            Serializer<char>.Instance = new CharSerializer();
            Serializer<short>.Instance = new ShortSerializer();
            Serializer<ushort>.Instance = new UShortSerializer();
            Serializer<int>.Instance = new IntSerializer();
            Serializer<uint>.Instance = new UIntSerializer();
            Serializer<float>.Instance = new FloatSerializer();
            Serializer<string>.Instance = new StringSerializer();
            Serializer<Vector2Int>.Instance = new Vector2IntSerializer();
        }
        
    }
}