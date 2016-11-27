using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Model;

namespace Tumblr.Services
{
    public class ConnectionService : IConnectionService
    {
        #region [ PRIVATE ]
        INetworkService _networkService;
        ISerializationService _serializationService;
        ITumblrResponseParserService _tumblrResponseParserService;

        // Interceptor
        private async Task<T> GetAsync<T>(string url)
        {
            if (!Network.IsConnected)
                return default(T);

            var result = await _networkService.GetAsync(url);

#if DEBUG
            Debug.WriteLine(string.Format("HTTP CODE: {0}", result.StatusCode));
#endif
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    string json = await _tumblrResponseParserService.ExtractJsonString( await (result as HttpResponseMessage).Content.ReadAsStringAsync());
#if DEBUG
                    Debug.WriteLine(json);
#endif
                    if (!string.IsNullOrEmpty(json))
                    {
                        var response = await _serializationService.Deserialize<T>(json);
                        return response;
                    }
                    return default(T);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">user's name</param>
        /// <param name="id">post's id</param>
        /// <returns></returns>
        public async Task<T> GetSinglePostAsync<T>(string user, string id)
        {
            TumblrUrlBuilder builder = new TumblrUrlBuilder(user);
            builder.PostId = id;
            var url = builder.GetUrl();
            T result = await GetAsync<T>(url);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">user's name</param>
        /// <param name="start">first post's index</param>
        /// <param name="num">number of posts to fetch</param>
        /// <returns></returns>
        public async Task<T> GetPostsAsync<T>(string user, int start, int num)
        {
            TumblrUrlBuilder builder = new TumblrUrlBuilder(user);
            builder.Start = start;
            builder.Num = num;
            var url = builder.GetUrl();
            T result = await GetAsync<T>(url);
            return result;
        }


        public ConnectionService(INetworkService networkService,
                                 ISerializationService serializationService,
                                 ITumblrResponseParserService tumblrResponseParserService)
        {
            _networkService = networkService;
            _serializationService = serializationService;
            _tumblrResponseParserService = tumblrResponseParserService;
        }

    }
}
