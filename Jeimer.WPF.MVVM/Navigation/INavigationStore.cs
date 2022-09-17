using Jeimer.WPF.MVVM.ViewModels;

namespace Jeimer.WPF.MVVM.Navigation
{
    public interface INavigationStore
    {
        public ViewModelBase? CurrentViewModel { get; set; }

        public event Action NavigationChanged;
    }
}
