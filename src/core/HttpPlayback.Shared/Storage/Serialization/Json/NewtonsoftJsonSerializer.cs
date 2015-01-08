using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace HttpPlayback.Shared.Storage.Serialization.Json
{
    /// <summary>
    /// JSON.NET - powered serializer. Stores in verbose JSON textual format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NewtonsoftJsonSerializer<T> : ISerializer<T> where T : new()
    {
        private readonly JsonSerializerSettings _settings;

        public NewtonsoftJsonSerializer(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public NewtonsoftJsonSerializer() : this(new JsonSerializerSettings())
        {
        }

        public T Deserialize(Stream bytes)
        {
            using (var sr = new StreamReader(bytes))
            {
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd(), _settings);
            }
        }

        public Stream Serialize(T obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, typeof(T), _settings);
            var stringBuffer = Encoding.UTF8.GetBytes(jsonString);
            return new MemoryStream(stringBuffer);
        }
    }
}