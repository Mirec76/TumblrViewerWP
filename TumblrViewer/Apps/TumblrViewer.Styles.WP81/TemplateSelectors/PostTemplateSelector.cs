using TumblrViewer.ViewModels.Items;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TumblrViewer.Styles.WP81.TemplateSelectors
{
    public class PostTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoadNext { get; set; }
        public DataTemplate TextPostItem { get; set; }
        public DataTemplate QuotePostItem { get; set; }
        public DataTemplate PhotoPostItem { get; set; }
        public DataTemplate LinkPostItem { get; set; }
        public DataTemplate ChatPostItem { get; set; }
        public DataTemplate VideoPostItem { get; set; }
        public DataTemplate AudioPostItem { get; set; }
        public DataTemplate NotSupportedPostItem { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is LoadNextListItemViewModel)
                return LoadNext;
            if (item is TextPostItemViewModel)
                return TextPostItem;
            if (item is QuotePostItemViewModel)
                return QuotePostItem;
            if (item is PhotoPostItemViewModel)
                return PhotoPostItem;
            if (item is LinkPostItemViewModel)
                return LinkPostItem;
            if (item is ChatPostItemViewModel)
                return ChatPostItem;
            if (item is VideoPostItemViewModel)
                return VideoPostItem;
            if (item is AudioPostItemViewModel)
                return AudioPostItem;
            if (item is NotSupportedPostItemViewModel)
                return NotSupportedPostItem;
            return null;
        }
    }
}
