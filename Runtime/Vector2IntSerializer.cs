using UnityEngine;
using System.IO;

namespace TinySerializer
{
    public class Vector2IntSerializer : Serializer<Vector2Int>
    {

        private char[] _tempChars;
        
        public override void Serialize(Stream stream, Vector2Int value)
        {
            IntSerializer.Instance.Serialize(stream, value.x);
            IntSerializer.Instance.Serialize(stream, value.x);
        }

        public override Vector2Int Deserialize(Stream stream)
        {
            var x = IntSerializer.Instance.Deserialize(stream);
            var y = IntSerializer.Instance.Deserialize(stream);
            return new Vector2Int(x, y);
        }
    }
}