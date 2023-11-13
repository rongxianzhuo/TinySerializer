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
            Serializer<bool>.Instance = new StructSerializer<bool>();
            Serializer<byte>.Instance = new ByteSerializer();
            Serializer<char>.Instance = new StructSerializer<char>();
            Serializer<short>.Instance = new StructSerializer<short>();
            Serializer<ushort>.Instance = new StructSerializer<ushort>();
            Serializer<int>.Instance = new StructSerializer<int>();
            Serializer<uint>.Instance = new StructSerializer<uint>();
            Serializer<float>.Instance = new StructSerializer<float>();
            Serializer<long>.Instance = new StructSerializer<long>();
            Serializer<double>.Instance = new StructSerializer<double>();
            Serializer<Vector2>.Instance = new StructSerializer<Vector2>();
            Serializer<Vector3>.Instance = new StructSerializer<Vector3>();
            Serializer<Vector4>.Instance = new StructSerializer<Vector4>();
            Serializer<Vector2Int>.Instance = new StructSerializer<Vector2Int>();
            Serializer<Vector3Int>.Instance = new StructSerializer<Vector3Int>();
            Serializer<Quaternion>.Instance = new StructSerializer<Quaternion>();
            Serializer<string>.Instance = new StringSerializer();
        }

        protected static unsafe void WriteBytes(Stream stream, byte* bytes, int count)
        {
            for (var i = 0; i < count; i++)
            {
                stream.WriteByte(bytes[i]);
            }
        }

        protected static unsafe void ReadBytes(Stream stream, byte* bytes, int count)
        {
            for (var i = 0; i < count; i++)
            {
                bytes[i] = (byte) stream.ReadByte();
            }
        }
        
    }
}