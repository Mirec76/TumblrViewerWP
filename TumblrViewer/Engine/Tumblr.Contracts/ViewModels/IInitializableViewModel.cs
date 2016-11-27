using System.Threading.Tasks;

namespace Tumblr.Contracts.ViewModels
{
    public interface IInitializableViewModel
    {
        Task InitializeAsync();
        Task InitializeAsync(object parameter);
        Task RefreshAsync();

        bool InProgress { get; }
        bool IsInitialized { get; set; }
    }
}
