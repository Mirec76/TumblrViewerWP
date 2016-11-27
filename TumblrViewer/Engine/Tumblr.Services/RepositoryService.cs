using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Model;
using Tumblr.Model.ApiModels;
using System.Linq;

namespace Tumblr.Services
{
    public class RepositoryService : IRepositoryService
    {
        #region [ PRIVATE ]
        private string _userName = string.Empty;
        private List<Post> _posts = new List<Post>();

        IConnectionService _connectionService;

        #endregion

        public int TotalNumberOfPosts { get; private set; }
        public int DownloadedPosts { get { return _posts.Count; } }
        public string UserName { get { return _userName; } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">post's id</param>
        /// <returns></returns>
        public async Task<Post> GetSinglePostAsync(string id)
        {
            var response =  await _connectionService.GetSinglePostAsync<ApiResponse>(_userName, id);
            if (response != null && response.posts != null)
                return response.posts.FirstOrDefault();
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">user's name</param>
        /// <param name="start">first post's index</param>
        /// <param name="num">number of posts to fetch</param>
        /// <returns></returns>
        public async Task<IList<Post>> GetPostsAsync(int start, int num, bool addToCache)
        {
            if (TotalNumberOfPosts > 0)
            {
                if (start >= TotalNumberOfPosts)
                    return null;
                if (start + num > TotalNumberOfPosts)
                    num = TotalNumberOfPosts - start;
            }
            if (start + num <= DownloadedPosts)
                return _posts.GetRange(start, num);

            var response = await _connectionService.GetPostsAsync<ApiResponse>(_userName, start, num);
            if (response != null && response.posts != null)
            {
                TotalNumberOfPosts = response.posts_total;
                if(addToCache)
                    _posts.AddRange(response.posts);
                return response.posts;
            }
            return null;
        }


        public RepositoryService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
            ClearLocalCache();
        }

        public async Task SetUserName(string userName)
        {
            if (userName.Equals(_userName))
                return;
            ClearLocalCache();
            _userName = userName;
            await GetPostsAsync(0, 1, false);
        }

        private void ClearLocalCache()
        {
            _userName = string.Empty;
            _posts.Clear();
            TotalNumberOfPosts = 0;

        }

    }
}
