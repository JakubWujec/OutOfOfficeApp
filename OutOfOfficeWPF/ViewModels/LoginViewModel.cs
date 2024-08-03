using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        public ICommand LoginCommand { get; }
        private readonly NavigationService navigationService;
        private readonly IAuthenticator authenticator;
        public LoginViewModel(NavigationService navigationService, IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
            this.navigationService = navigationService;
            this.LoginCommand = new LoginCommand(authenticator, navigationService);
        }

    }
}
