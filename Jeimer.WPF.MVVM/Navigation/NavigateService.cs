using Jeimer.WPF.MVVM.ViewModels;

namespace Jeimer.WPF.MVVM.Navigation
{
    public class NavigateService<TViewModel> : INavigateService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly Func<TViewModel> _factory;

        public NavigateService(INavigationStore navigationStore,
                               Func<TViewModel> factory)
        {
            _navigationStore = navigationStore;
            _factory = factory;
        }

        public void Navigate() => _navigationStore.CurrentViewModel = _factory();
    }
}
