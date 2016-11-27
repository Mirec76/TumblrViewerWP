using System.Collections.ObjectModel;
using System.Windows.Input;
using Tumblr.Contracts.ViewModels.Items;

namespace Tumblr.Contracts.ViewModels.Views
{
    public interface IMainViewModel : IInitializableViewModel, ICommands
    {
        ObservableCollection<object> Posts { get; }
        ICommand RefreshViewCommand { get; }
    }
}
