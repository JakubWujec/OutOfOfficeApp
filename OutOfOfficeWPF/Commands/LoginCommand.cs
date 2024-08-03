using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly NavigationService navigationService;
        private readonly IAuthenticator authenticator;
        public LoginCommand(IAuthenticator authenticator, NavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.authenticator = authenticator;
        }
        public override void Execute(object? parameter)
        {
            authenticator.Login();
            navigationService.Navigate();
        }
    }
}
