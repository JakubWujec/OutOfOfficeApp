using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class LoginCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigationService<HomeViewModel> navigationService;
        private readonly IAuthenticator authenticator;
        private readonly LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel, IAuthenticator authenticator, INavigationService<HomeViewModel> navigationService)
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
