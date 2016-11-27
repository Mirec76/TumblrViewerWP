using Tumblr.Common;
using Tumblr.Contracts;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels.Views;
using Tumblr.Contracts.Views;
using Tumblr.Services;
using TumblrViewer.App.WP81.Views;
using TumblrViewer.ViewModels.Views;

namespace TumblrViewer.App.WP81
{
    class Locator : ILocator
    {
        public Locator()
        {
            RegisterViews();
            RegisterViewModels();
            RegisterServices();

            InstanceFactory.Build();
        }
        public void RegisterViews()
        {
            InstanceFactory.RegisterType<ILoginView, LoginView>();
            InstanceFactory.RegisterType<IMainView, MainView>();
            InstanceFactory.RegisterType<IWebView, WebView>();
        }

        public void RegisterViewModels()
        {
            InstanceFactory.RegisterType<ILoginViewModel, LoginViewModel>();
            InstanceFactory.RegisterType<IMainViewModel, MainViewModel>();
            InstanceFactory.RegisterType<IWebViewModel, WebViewModel>();
        }

        public void RegisterServices()
        {
            InstanceFactory.RegisterType<ITumblrDataValidationService, TumblrDataValidationService>();
            InstanceFactory.RegisterType<ITumblrResponseParserService, TumblrResponseParserService>();
            InstanceFactory.RegisterType<INavigationService, NavigationService>();
            InstanceFactory.RegisterType<ISerializationService, JsonSerializationService>();
            InstanceFactory.RegisterType<INetworkService, NetworkService>();
            InstanceFactory.RegisterType<IConnectionService, ConnectionService>();
            InstanceFactory.RegisterType<IRepositoryService, RepositoryService>();
        }

    }
}
