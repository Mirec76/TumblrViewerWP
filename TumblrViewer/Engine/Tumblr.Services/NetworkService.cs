using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Tumblr.Contracts.Services;

namespace Tumblr.Services
{
    public class NetworkService : INetworkService
    {
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpResponseMessage result = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    var handler = new HttpClientHandler { AllowAutoRedirect = true };

                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);

                    var httpClient = new HttpClient(handler);

                    var userAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";

//                    httpClient.DefaultRequestHeaders.Add("user-agent", userAgent);
//                    httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    var response = await httpClient.SendAsync(message).ConfigureAwait(false);

                    result = response;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GET error. Url: " + url, ex);
            }
            return result;
        }

    }
}
