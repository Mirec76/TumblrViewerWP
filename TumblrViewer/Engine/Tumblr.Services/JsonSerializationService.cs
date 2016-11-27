using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Tumblr.Contracts.Services;

namespace Tumblr.Services
{
    public class JsonSerializationService : ISerializationService
    {
        public IList<Type> KnownTypes { get; set; }
        public async Task<string> Serialize<T>(T instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), KnownTypes);
            string content = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                stream.Position = 0;
                content = new StreamReader(stream).ReadToEnd();
            }
            return content;
        }

        public async Task<T> Deserialize<T>(string input)
        {
            var bytes = Encoding.Unicode.GetBytes(input);
            var serializer = new DataContractJsonSerializer(typeof(T));

            return (T)serializer.ReadObject(new MemoryStream(bytes));
        }
    }
}
