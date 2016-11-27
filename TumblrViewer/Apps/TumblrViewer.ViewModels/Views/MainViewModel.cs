using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TinyMvvm;
using Tumblr.Contracts.Services;
using Tumblr.Contracts.ViewModels.Views;
using TumblrViewer.ViewModels.Items;
using Windows.ApplicationModel.Resources;
using Windows.System.Threading;

namespace TumblrViewer.ViewModels.Views
{
    public class MainViewModel : ViewModelBase, IMainViewModel, ILoadNextObserver
    {
        private const int DOWNLOAD_CHUNK_SIZE = 20; // number of posts to download
        private int _displayedPosts = 0;
        private INavigationService _navigationService;
        private IRepositoryService _repositoryService;
        private ResourceLoader _resourceLoader;

        public ObservableCollection<object> Posts { get; set; }
        public ICommand RefreshViewCommand { get; private set; }


        public MainViewModel(INavigationService navigationService,
            IRepositoryService repositoryService
            )
        {
            Posts = new ObservableCollection<object>();
            this._resourceLoader = new ResourceLoader();
            this._navigationService = navigationService;
            this._repositoryService = repositoryService;
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
            Posts.Clear();
            UpdateBindedProperties();
            await LoadPosts(0, DOWNLOAD_CHUNK_SIZE);
        }

        public async Task RefreshAsync()
        {
        }

        public void InitializeCommands()
        {
            RefreshViewCommand = new RelayCommand(async () =>
            {
                if (InProgress)
                    return;
            });
        }

        private async Task LoadPosts(int start, int number)
        {
            var posts = await _repositoryService.GetPostsAsync(start, number, true);
            if (posts != null)
            {
                foreach (var post in posts)
                {
                    PostItemViewModel vm = null;
                    vm = PostItemVMFactory.CreateViewModel(post);
                    if (vm != null)
                        Posts.Add(vm);
                }
                _displayedPosts = posts.Count;
                if (_displayedPosts < _repositoryService.TotalNumberOfPosts)
                    Posts.Add(new LoadNextListItemViewModel(_resourceLoader.GetString("DownloadingPosts"), this));
                UpdateBindedProperties();
            }
        }

        public async Task LoadMore(object parameter)
        {
            await DoLoadNextChunkAsync(null);
        }

        private async Task DoLoadNextChunkAsync(object param)
        {
            if (InProgress)
                return;
            InProgress = true;
            var dispatcher = Windows.UI.Xaml.Window.Current.Dispatcher;
            ThreadPool.RunAsync(async (a) =>
            {
                var posts = await _repositoryService.GetPostsAsync(_displayedPosts, DOWNLOAD_CHUNK_SIZE, true);
                dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    if (Posts.Last() is LoadNextListItemViewModel)
                    {
                        var last = Posts.Last(x => x is LoadNextListItemViewModel);
                        if (last != null)
                            Posts.Remove(last);
                    }
                    if (posts != null)
                    {
                        foreach (var post in posts)
                        {
                            PostItemViewModel vm = null;
                            vm = PostItemVMFactory.CreateViewModel(post);
                            if (vm != null)
                                Posts.Add(vm);
                        }
                        _displayedPosts += posts.Count;

                        if (_displayedPosts < _repositoryService.TotalNumberOfPosts)
                            Posts.Add(new LoadNextListItemViewModel(_resourceLoader.GetString("DownloadingPosts"), this));
                    }
                    InProgress = false;
                    UpdateBindedProperties();
                });
            });
        }



        public string UserName
        {
            get { return _repositoryService.UserName; }
        }

        public string NumberOfPosts
        {
            get { return string.Format( _resourceLoader.GetString("DownloadedPostsPattern"), _repositoryService.DownloadedPosts, _repositoryService.TotalNumberOfPosts); }
        }

        private void UpdateBindedProperties()
        {
            RaisePropertyChanged("UserName");
            RaisePropertyChanged("NumberOfPosts");
        }
    }
}
