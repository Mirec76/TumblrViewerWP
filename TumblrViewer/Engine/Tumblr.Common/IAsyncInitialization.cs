using System.Threading.Tasks;

namespace Tumblr.Common
{
    public interface IAsyncInitialization
    {
        bool IsInitialized { get; }
        Task Initialize();
    }
}
