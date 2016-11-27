using System.Threading.Tasks;

namespace Tumblr.Contracts.Services
{
    public interface IConnectionService
    {
        Task<T> GetSinglePostAsync<T>(string user, string id);
        Task<T> GetPostsAsync<T>(string user, int start, int num);
    }
}
