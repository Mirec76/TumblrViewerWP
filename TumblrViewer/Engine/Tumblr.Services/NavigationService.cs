using System;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels;
using Tumblr.Contracts.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Tumblr.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        private Frame _frame;

        public int ViewsCount { get; private set; }

        public IViewBase CurrentView
        {
            get { return _frame.Content as IViewBase; }
        }

        public Frame Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                _frame.Navigated += OnFrameNavigated;
            }
        }

        public bool CanGoBack
        {
            get { return Frame.CanGoBack; }
        }

        public void Navigate(Type type)
        {
            Frame.Navigate(type);
        }

        public void Navigate(Type type, object parameter)
        {
            Frame.Navigate(type, parameter);
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            var view = e.Content as IViewBase;
            if (view == null)
                return;

            if (e.NavigationMode == NavigationMode.Back)
                ViewsCount--;
            if (e.NavigationMode == NavigationMode.Forward || e.NavigationMode == NavigationMode.New)
                ViewsCount++;

            IInitializableViewModel viewModel = view.ViewModel;
            if (viewModel != null)
            {
                if (CheckIfIsNavigatingFirstTime(e))
                {
                    viewModel.InitializeAsync(e.Parameter);
                }

                if (e.NavigationMode != NavigationMode.New)
                {
                    viewModel.RefreshAsync();
                }
            }
        }

        private static bool CheckIfIsNavigatingFirstTime(NavigationEventArgs navigationEventArgs)
        {
            return !(navigationEventArgs.NavigationMode == NavigationMode.Back &&
                     (((Page)navigationEventArgs.Content).NavigationCacheMode == NavigationCacheMode.Enabled ||
                      (((Page)navigationEventArgs.Content).NavigationCacheMode == NavigationCacheMode.Required)));
        }

        public void ClearBackstack()
        {
            if (Frame != null)
                Frame.BackStack.Clear();
        }

    }

}
