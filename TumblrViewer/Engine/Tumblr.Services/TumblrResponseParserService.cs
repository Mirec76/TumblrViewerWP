using System.Threading.Tasks;
using Tumblr.Common;
using Tumblr.Contracts.Services;

namespace Tumblr.Services
{
    public class TumblrResponseParserService : ITumblrResponseParserService
    {
        #region [ PRIVATE ]
        private static string _POST_TYPE_TEXT = "text";
        private static string _POST_TYPE_QUOTE = "quote";
        private static string _POST_TYPE_PHOTO = "photo";
        private static string _POST_TYPE_LINK = "link";
        private static string _POST_TYPE_CHAT = "chat";
        private static string _POST_TYPE_VIDEO = "video";
        private static string _POST_TYPE_AUDIO = "audio";


        #endregion



        public async Task<string> ExtractJsonString(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                return null;
            int startIndex = response.IndexOf('{');
            int endIndex = response.LastIndexOf('}');
            if (startIndex >= 0 && endIndex > startIndex)
                return response.Substring(startIndex, endIndex - startIndex + 1);

            return null;
        }



        public TumblrPostType TypeNameToEnum(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return TumblrPostType._UNKNOWN;
            if (name.Equals(_POST_TYPE_AUDIO))
                return TumblrPostType.audio;
            if (name.Equals(_POST_TYPE_CHAT))
                return TumblrPostType.chat;
            if (name.Equals(_POST_TYPE_LINK))
                return TumblrPostType.link;
            if (name.Equals(_POST_TYPE_PHOTO))
                return TumblrPostType.photo;
            if (name.Equals(_POST_TYPE_QUOTE))
                return TumblrPostType.quote;
            if (name.Equals(_POST_TYPE_TEXT))
                return TumblrPostType.text;
            if (name.Equals(_POST_TYPE_VIDEO))
                return TumblrPostType.video;


            return TumblrPostType._UNKNOWN;
        }
    }
}
