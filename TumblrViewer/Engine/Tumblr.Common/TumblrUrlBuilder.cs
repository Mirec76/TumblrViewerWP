namespace Tumblr.Common
{
    public class TumblrUrlBuilder
    {
        #region [ CONSTS ]
        private const int DEFAULT_START = 0;
        private const int DEFAULT_NUM = 20;
        private const int MAX_NUM = 50;

        private const string HOST_PATTERN = @"http://{0}.tumblr.com/";
        private const string ENDPOINT_GET_JSON = @"api/read/json/";
        private const string ENDPOINT_GET_XML = @"api/read/"; // Not supported!
        private const string FIRST_PARAM_PATTERN = @"?{0}={1}";
        private const string NEXT_PARAM_PATTERN = @"&{0}={1}";

        private const string PARAM_NAME_START = @"start";
        private const string PARAM_NAME_NUM = @"num";

        #endregion


        public enum PostTypes
        {
            any,
            text,
            quote,
            photo,
            link,
            chat,
            video,
            audio
        }

        public enum PostFilters
        {
            text,
            none, 
            tagged
            /*
                text - Plain text only.No HTML.
                none - No post-processing.Output exactly what the author entered. (Note: Some authors write in Markdown, which will not be converted to HTML when this option is used.)
                tagged - Return posts with this tag in reverse-chronological order (newest first). Optionally specify chrono=1 to sort in chronological order (oldest first).    }
             */
        }

        string _host = "";
        int _start = DEFAULT_START; //The post offset to start from.The default is 0.
        int _num = DEFAULT_NUM; //The number of posts to return. The default is 20, and the maximum is 50.

        public TumblrUrlBuilder(string user)
        {
            _host = string.Format(HOST_PATTERN, user);
            PostType = PostTypes.any;
            PostFilter = PostFilters.text;
            PostId = string.Empty;
            NewestFirst = true;
        }

        public string GetUrl()
        {
            string url = _host;
            url += ENDPOINT_GET_JSON;
            AddParameter(ref url, PARAM_NAME_START, Start.ToString());
            AddParameter(ref url, PARAM_NAME_NUM, Num.ToString());


            return url;
        }

        public int Start
        {
            get { return _start; }
            set { _start = value > 0 ? value : DEFAULT_START; }
        }

        public int Num
        {
            get { return _num; }
            set { _num = value < MAX_NUM ? (value > 0 ? value : DEFAULT_NUM) : MAX_NUM; }
        }

        public PostTypes PostType { get; set; }
        public PostFilters PostFilter { get; set; }
        public string PostId { get; set; }
        public bool NewestFirst { get; set; }


        private void AddParameter(ref string source, string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(source))
                return;
            if (source.Contains("?"))
                source += string.Format(NEXT_PARAM_PATTERN, paramName, paramValue);
            else
                source += string.Format(FIRST_PARAM_PATTERN, paramName, paramValue);
        }

    }

}
