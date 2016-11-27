using System.Windows.Input;

namespace Tumblr.Contracts.ViewModels.Items
{
    public interface IPostItemViewModel
    {
        ICommand ShowDetailsCommand { get; }
        string Id { get;}
        string Url { get;}
        string DaysAfterPublication { get; }
        string Slug { get; }

    }
}
