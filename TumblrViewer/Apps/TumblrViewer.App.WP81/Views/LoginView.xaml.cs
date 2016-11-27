using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels;
using Tumblr.Contracts.ViewModels.Views;
using Tumblr.Contracts.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TumblrViewer.App.WP81.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page, ILoginView
    {
        public LoginView()
        {
            this.InitializeComponent();
            DataContext = InstanceFactory.GetInstance<ILoginViewModel>();
        }

        public IInitializableViewModel ViewModel
        {
            get { return DataContext as IInitializableViewModel; }
        }

        public ILoginViewModel LoginViewModel
        {
            get { return DataContext as ILoginViewModel; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navigationService = InstanceFactory.GetInstance<INavigationService>();
            navigationService.ClearBackstack();
        }

        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            var be = (sender as TextBox).GetBindingExpression(TextBox.TextProperty);
            if (be != null)
                be.UpdateSource();
            if (e.Key == Windows.System.VirtualKey.Enter)
                LoginViewModel.LoginCommand.Execute(null);
        }
    }
}
