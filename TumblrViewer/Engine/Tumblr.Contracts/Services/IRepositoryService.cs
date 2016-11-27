using System.Collections.Generic;
using System.Threading.Tasks;
using Tumblr.Model.ApiModels;

namespace Tumblr.Contracts.Services
{
    public interface IRepositoryService
    {
        Task<Post> GetSinglePostAsync(string id);
        Task<IList<Post>> GetPostsAsync(int start, int num, bool addToCache);
        Task SetUserName(string userName);
        string UserName { get; }
        int TotalNumberOfPosts { get; }
        int DownloadedPosts { get; }
    }
}
