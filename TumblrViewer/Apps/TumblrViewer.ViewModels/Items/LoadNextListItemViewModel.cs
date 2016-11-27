using System.Threading.Tasks;
using TinyMvvm;

namespace TumblrViewer.ViewModels.Items
{
    public interface ILoadNextObserver
    {
        Task LoadMore(object parameter);
    }
    public class LoadNextListItemViewModel : ViewModelBase
    {
        ILoadNextObserver _observer;
        private bool _inProgress = false;
        private string _label;
        object _parameter;

        public string Label
        {
            get
            {
                if (!_inProgress && _observer != null)
                {
                    _inProgress = true;
                    _observer.LoadMore(_parameter);
                }
                return _label;
            }
            set
            {
                _label = value;
            }
        }

        public LoadNextListItemViewModel(string label, ILoadNextObserver observer, object parameter = null)
        {
            _label = label;
            _observer = observer;
            _parameter = parameter;
        }

    }

}
