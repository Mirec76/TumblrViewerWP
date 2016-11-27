using System;
using Tumblr.Contracts.Views;
using Windows.UI.Xaml.Controls;

namespace Tumblr.Contracts.Services
{
    public interface INavigationService
    {
        int ViewsCount { get; }

        IViewBase CurrentView { get; }
        Frame Frame { get; set; }
        bool CanGoBack { get; }
        void Navigate(Type type);
        void Navigate(Type type, object parameter);
        void GoBack();
        void ClearBackstack();
    }
}
