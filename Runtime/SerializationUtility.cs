using System.IO;

namespace TinySerializer
{
    public static class SerializationUtility
    {

        public static void SerializeArray<T>(Stream stream, T[] array)
        {
            Serializer<int>.Instance.Serialize(stream, array.Length);
            foreach (var value in array)
            {
                Serialize(stream, value);
            }
        }

        public static T[] DeserializeArray<T>(Stream stream)
        {
            var result = new T[Serializer<int>.Instance.Deserialize(stream)];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Deserialize<T>(stream);
            }
            return result;
        }

        public static void Serialize<T>(Stream stream, T value)
        {
            Serializer<T>.Instance.Serialize(stream, value);
        }

        public static T Deserialize<T>(Stream stream)
        {
            return Serializer<T>.Instance.Deserialize(stream);
        }

        public static void RegisterSerializer<T>(Serializer<T> instance)
        {
            Serializer<T>.Instance = instance;
        }
        
    }
}