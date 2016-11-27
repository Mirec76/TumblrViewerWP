using System.Windows.Input;

namespace Tumblr.Contracts.ViewModels.Views
{
    public interface ILoginViewModel : IInitializableViewModel, ICommands
    {
        string UserName { get; set; }
        ICommand LoginCommand { get; }
    }
}
