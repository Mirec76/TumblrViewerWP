using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tumblr.Common;
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
    public sealed partial class WebView : Page, IWebView
    {
        public WebView()
        {
            this.InitializeComponent();
            DataContext = InstanceFactory.GetInstance<IWebViewModel>();
        }

        public IInitializableViewModel ViewModel
        {
            get { return DataContext as IInitializableViewModel; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void webview_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            progressRing.IsEnabled = false;
            progressRing.IsActive = false;
            //ToDo: handle navigation error
        }

        private void webview_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            webview.Opacity = 1;
            progressRing.IsEnabled = false;
            progressRing.IsActive = false;
        }

        private void webview_NavigationStarting(Windows.UI.Xaml.Controls.WebView sender, WebViewNavigationStartingEventArgs args)
        {
            webview.Opacity = 0;
            progressRing.IsEnabled = true;
            progressRing.IsActive = true;
        }
    }
}
