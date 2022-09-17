using Jeimer.WPF.MVVM.ViewModels;

namespace Jeimer.WPF.MVVM.Navigation
{
    public interface INavigateService<TViewModel> where TViewModel : ViewModelBase
    {
        public void Navigate();
    }
}
