using System;
using System.Windows.Input;
using TinyMvvm;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels.Items;
using Tumblr.Contracts.Views;
using Tumblr.Model.ApiModels;
using Windows.ApplicationModel.Resources;

namespace TumblrViewer.ViewModels.Items
{
    public abstract class PostItemViewModel : IPostItemViewModel
    {
        ResourceLoader _resourceLoader = new ResourceLoader();

        protected PostItemViewModel(Post model)
        {
            this.Id = model.id;
            this.Url = model.url;
            this.Slug = model.slug;
            DateTime publicationDate;
            if(DateTime.TryParse(model.date_gmt, out publicationDate))
            {
                int days = (int)DateTime.Now.Subtract(publicationDate.ToLocalTime()).TotalDays;
                DaysAfterPublication = string.Format(_resourceLoader.GetString("DaysAfterPublicationPattern"), days);
            }


            ShowDetailsCommand = new RelayCommand(() =>
            {
                if(!string.IsNullOrWhiteSpace(Url))
                {
                    var navigationService = InstanceFactory.GetInstance<INavigationService>();
                    navigationService.Navigate(InstanceFactory.GetInstanceType<IWebView>(), this);
                }
            });

        }

        public ICommand ShowDetailsCommand { get; protected set; }
        public string Id { get; private set; }
        public string Url { get; private set; }
        public string Slug { get; private set; }
        public string DaysAfterPublication { get; private set; }
    }

    public class NotSupportedPostItemViewModel : PostItemViewModel
    {
        public NotSupportedPostItemViewModel(Post model)
            : base(model)
        {
            ShowDetailsCommand = null;
        }

    }

    public class TextPostItemViewModel : PostItemViewModel
    {
        public TextPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class QuotePostItemViewModel : PostItemViewModel
    {
        public QuotePostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class PhotoPostItemViewModel : PostItemViewModel
    {
        public PhotoPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class LinkPostItemViewModel : PostItemViewModel
    {
        public LinkPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class ChatPostItemViewModel : PostItemViewModel
    {
        public ChatPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class VideoPostItemViewModel : PostItemViewModel
    {
        public VideoPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

    public class AudioPostItemViewModel : PostItemViewModel
    {
        public AudioPostItemViewModel(Post model)
            :base(model)
        {

        }

    }

}
