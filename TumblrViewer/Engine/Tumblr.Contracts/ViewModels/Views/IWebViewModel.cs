using System;

namespace Tumblr.Contracts.ViewModels.Views
{
    public interface IWebViewModel : IInitializableViewModel
    {
        Uri WebViewUriSource { get; }
    }
}
