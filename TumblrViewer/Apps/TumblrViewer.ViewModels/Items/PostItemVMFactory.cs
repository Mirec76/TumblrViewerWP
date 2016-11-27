using System.Diagnostics;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Model.ApiModels;

namespace TumblrViewer.ViewModels.Items
{
    public static class PostItemVMFactory
    {
        public static PostItemViewModel CreateViewModel(Post model)
        {
            if (model == null)
                return null;
            PostItemViewModel vm = null;
            var tumblrResponseParserService = InstanceFactory.GetInstance<ITumblrResponseParserService>();
            var postType = tumblrResponseParserService.TypeNameToEnum(model.type);

            switch (postType)
            {
                case TumblrPostType.audio:
                        return new AudioPostItemViewModel(model);
                case TumblrPostType.chat:
                    return new ChatPostItemViewModel(model);
                case TumblrPostType.link:
                    return new LinkPostItemViewModel(model);
                case TumblrPostType.photo:
                    return new PhotoPostItemViewModel(model);
                case TumblrPostType.quote:
                    return new QuotePostItemViewModel(model);
                case TumblrPostType.text:
                    return new TextPostItemViewModel(model);
                case TumblrPostType.video:
                    return new VideoPostItemViewModel(model);
                default:
                    Debug.WriteLine("Unknown type of Post: '{0}'", model.type);
                    return new NotSupportedPostItemViewModel(model);
            }
        }
    }
}
