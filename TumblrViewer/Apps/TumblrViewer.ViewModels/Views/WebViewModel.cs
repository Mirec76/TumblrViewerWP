using System;
using System.Threading.Tasks;
using TinyMvvm;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels.Items;
using Tumblr.Contracts.ViewModels.Views;
using Windows.ApplicationModel.Resources;

namespace TumblrViewer.ViewModels.Views
{
    public class WebViewModel : ViewModelBase, IWebViewModel
    {
        private INavigationService _navigationService;
        private ResourceLoader _resourceLoader;


        public WebViewModel(INavigationService navigationService)
        {
            this._resourceLoader = new ResourceLoader();
            this._navigationService = navigationService;

        }
        private bool _InProgress = false;
        public bool InProgress
        {
            get { return _InProgress; }
            set
            {
                if (value != _InProgress)
                {
                    _InProgress = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _IsInitialized = false;
        public bool IsInitialized
        {
            get { return _IsInitialized; }
            set
            {
                if (value != _IsInitialized)
                {
                    _IsInitialized = value;
                    RaisePropertyChanged();
                }
            }
        }


        public async Task InitializeAsync()
        {
        }

        public async Task InitializeAsync(object parameter)
        {
            if (parameter is IPostItemViewModel)
            {
                var vm = parameter as IPostItemViewModel;
                WebViewUriSource = new Uri(vm.Url);
            }
        }

        public async Task RefreshAsync()
        {
        }

        private Uri _WebViewUriSource = null;
        public Uri WebViewUriSource
        {
            get { return _WebViewUriSource; }
            private set
            {
                if (_WebViewUriSource == null || !_WebViewUriSource.Equals(value))
                {
                    _WebViewUriSource = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
