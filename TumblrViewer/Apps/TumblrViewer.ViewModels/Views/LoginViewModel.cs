using System.Threading.Tasks;
using System.Windows.Input;
using TinyMvvm;
using Tumblr.Common;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels.Views;
using Tumblr.Contracts.Views;
using Windows.ApplicationModel.Resources;
using Windows.System.Threading;

namespace TumblrViewer.ViewModels.Views
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private INavigationService _navigationService;
        private ITumblrDataValidationService _tumblrDataValidationService;
        private IRepositoryService _repositoryService;
        private ResourceLoader _resourceLoader;

        public string UserName { get; set; }
        public ICommand LoginCommand { get; private set; }


        public LoginViewModel(INavigationService navigationService,
            ITumblrDataValidationService tumblrDataValidationService,
            IRepositoryService repositoryService)
        {
            this._resourceLoader = new ResourceLoader();
            this._navigationService = navigationService;
            this._tumblrDataValidationService = tumblrDataValidationService;
            this._repositoryService = repositoryService;
#if DEBUG
            this.UserName = _tumblrDataValidationService.DemoUserName;
#endif
            InitializeCommands();

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
        }

        public async Task RefreshAsync()
        {
        }

        public void InitializeCommands()
        {
            LoginCommand = new RelayCommand(() =>
            {
                if (ValidateInput())
                {
                    InProgress = true;
                    var dispatcher = Windows.UI.Xaml.Window.Current.Dispatcher;
                    ThreadPool.RunAsync(async (s)=>
                    {
                        await _repositoryService.SetUserName(UserName);
                        await _repositoryService.GetPostsAsync(0, 20, true);
                        dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            if (_repositoryService.TotalNumberOfPosts > 0)
                            {
                                _navigationService.Navigate(InstanceFactory.GetInstanceType<IMainView>());
                            }
                            else
                            {

                            }
                            InProgress = false;
                        });
                    });
                }
            });
        }

        private bool ValidateInput()
        {
            if (!_tumblrDataValidationService.IsUserNameAcceptable(UserName))
            {
                // ToDo: show error message
                return false;
            }
            return true;
        }
    }
}
