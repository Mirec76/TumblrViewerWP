using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tumblr.Contracts.Services
{
    public interface ISerializationService
    {
        IList<Type> KnownTypes { get; set; }
        Task<string> Serialize<T>(T instance);
        Task<T> Deserialize<T>(string input);
    }
}
