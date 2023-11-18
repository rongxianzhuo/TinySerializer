using System.IO;

namespace TinySerializer
{
    
    public class StringSerializer : Serializer<string>
    {

        private char[] _tempChars;
        
        public override void Serialize(Stream stream, string value)
        {
            Serializer<int>.Instance.Serialize(stream, value.Length);
            foreach (var c in value)
            {
                CharSerializer.Instance.Serialize(stream, c);
            }
        }

        public override string Deserialize(Stream stream)
        {
            var length = Serializer<int>.Instance.Deserialize(stream);
            if (_tempChars == null || _tempChars.Length != length) _tempChars = new char[length];
            for (var i = 0; i < length; i++)
            {
                _tempChars[i] = CharSerializer.Instance.Deserialize(stream);
            }
            return new string(_tempChars);
        }
    }
}