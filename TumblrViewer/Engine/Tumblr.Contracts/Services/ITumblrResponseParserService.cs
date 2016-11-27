using System.Threading.Tasks;
using Tumblr.Common;

namespace Tumblr.Contracts.Services
{
    public interface ITumblrResponseParserService
    {
        Task<string> ExtractJsonString(string response);
        TumblrPostType TypeNameToEnum(string name);
    }
}
