using Jeimer.WPF.MVVM.Navigation;
using Jeimer.WPF.MVVM.ViewModels;

namespace Jeimer.WPF.MVVM.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigateService<TViewModel> _navigateService;

        public NavigateCommand(INavigateService<TViewModel> navigateService) => _navigateService = navigateService;

        public override void Execute(object? parameter) => _navigateService.Navigate();
    }
}
