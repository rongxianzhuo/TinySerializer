using System.IO;

namespace TinySerializer
{
    public static class SerializationUtility
    {

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