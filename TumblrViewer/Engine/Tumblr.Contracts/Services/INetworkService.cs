using System.Net.Http;
using System.Threading.Tasks;

namespace Tumblr.Contracts.Services
{
    public interface INetworkService
    {
        Task<HttpResponseMessage> GetAsync(string url);

    }
}
