using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tumblr.Model.ApiModels
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "tumblelog")]
        public TubmleLog tumblelog { get; set; }
        [DataMember(Name = "posts-start")]
        public int posts_start { get; set; }
        [DataMember(Name = "posts-total")]
        public int posts_total { get; set; }
        [DataMember(Name = "posts-type")]
        public bool posts_type { get; set; }
        [DataMember(Name = "posts")]
        public List<Post> posts { get; set; }
    }

    [DataContract]
    public class TubmleLog
    {
        [DataMember(Name = "title")]
        public string title { get; set; }
        [DataMember(Name = "description")]
        public string description { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "timezone")]
        public string timezone { get; set; }
        [DataMember(Name = "cname")]
        public dynamic cname { get; set; }
        [DataMember(Name = "feeds")]
        public List<object> feeds { get; set; }
    }

    [DataContract]
    public class Post
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "url")]
        public string url { get; set; }
        [DataMember(Name = "url-with-slug")]
        public string url_with_slug { get; set; }
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "date-gmt")]
        public string date_gmt { get; set; }
        [DataMember(Name = "date")]
        public string date { get; set; }
        [DataMember(Name = "bookmarklet")]
        public int bookmarklet { get; set; }
        [DataMember(Name = "mobile")]
        public int mobile { get; set; }
        [DataMember(Name = "feed-item")]
        public string feed_item { get; set; }
        [DataMember(Name = "from-feed-id")]
        public int from_feed_id { get; set; }
        [DataMember(Name = "unix-timestamp")]
        public int unix_timestamp { get; set; }
        [DataMember(Name = "format")]
        public string format { get; set; }
        [DataMember(Name = "reblog-key")]
        public string reblog_key { get; set; }
        [DataMember(Name = "slug")]
        public string slug { get; set; }
        [DataMember(Name = "is-submission")]
        public bool is_submission { get; set; }
        //"like-button": "<div class=\"like_button\" data-post-id=\"236\" data-blog-name=\"demo\" id=\"like_button_236\"><iframe id=\"like_iframe_236\" src=\"http:\/\/assets.tumblr.com\/assets\/html\/like_iframe.html?_v=399aee1ea58b6007c2190a8138f100e5#name=demo&amp;post_id=236&amp;color=black&amp;rk=iKvmNy9T\" scrolling=\"no\" width=\"20\" height=\"20\" frameborder=\"0\" class=\"like_toggle\" allowTransparency=\"true\" name=\"like_iframe_236\"><\/iframe><\/div>",
        //"reblog-button": "<a href=\"https:\/\/www.tumblr.com\/reblog\/236\/iKvmNy9T\" class=\"reblog_button\"style=\"display: block;width:20px;height:20px;\"><svg width=\"100%\" height=\"100%\" viewBox=\"0 0 21 21\" xmlns=\"http:\/\/www.w3.org\/2000\/svg\" xmlns:xlink=\"http:\/\/www.w3.org\/1999\/xlink\" fill=\"#ccc\"><path d=\"M5.01092527,5.99908429 L16.0088498,5.99908429 L16.136,9.508 L20.836,4.752 L16.136,0.083 L16.1360004,3.01110845 L2.09985349,3.01110845 C1.50585349,3.01110845 0.979248041,3.44726568 0.979248041,4.45007306 L0.979248041,10.9999998 L3.98376463,8.30993634 L3.98376463,6.89801007 C3.98376463,6.20867902 4.71892527,5.99908429 5.01092527,5.99908429 Z\"><\/path><path d=\"M17.1420002,13.2800293 C17.1420002,13.5720293 17.022957,14.0490723 16.730957,14.0490723 L4.92919922,14.0490723 L4.92919922,11 L0.5,15.806 L4.92919922,20.5103758 L5.00469971,16.9990234 L18.9700928,16.9990234 C19.5640928,16.9990234 19.9453125,16.4010001 19.9453125,15.8060001 L19.9453125,9.5324707 L17.142,12.203\"><\/path><\/svg><\/a>",
        [DataMember(Name = "quote-text")]
        public string quote_text { get; set; }
        [DataMember(Name = "quote-source")]
        public string quote_source { get; set; }
        [DataMember(Name = "tags")]
        public List<string> tags { get; set; }
    }






}
