using OutOfOfficeWPF.Services;

namespace OutOfOfficeWPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private INavigationService navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}
