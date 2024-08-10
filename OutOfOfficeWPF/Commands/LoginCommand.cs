using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly INavigationService navigationService;
        private readonly IAuthenticator authenticator;
        private readonly LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel, IAuthenticator authenticator, INavigationService navigationService)
        {
            this.viewModel = viewModel;
            this.navigationService = navigationService;
            this.authenticator = authenticator;
        }
        public override void Execute(object? parameter)
        {
            authenticator.Login(
                viewModel.SelectedEmployee.Id
            );
            navigationService.Navigate();
        }
    }
}
