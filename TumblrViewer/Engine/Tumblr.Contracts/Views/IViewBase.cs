using Tumblr.Contracts.ViewModels;

namespace Tumblr.Contracts.Views
{
    public interface IViewBase
    {
        IInitializableViewModel ViewModel { get; }
    }
}
