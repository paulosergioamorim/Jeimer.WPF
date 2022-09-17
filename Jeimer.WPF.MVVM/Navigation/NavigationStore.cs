using Jeimer.WPF.MVVM.ViewModels;

namespace Jeimer.WPF.MVVM.Navigation
{
    public class NavigationStore : INavigationStore
    {
        private ViewModelBase? _currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnNavigationChanged();
            }
        }

        public event Action? NavigationChanged;

        private void OnNavigationChanged() => NavigationChanged?.Invoke();
    }
}
