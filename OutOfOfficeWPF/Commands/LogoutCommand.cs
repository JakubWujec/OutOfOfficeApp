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
    public class LogoutCommand : CommandBase
    {
        private readonly IAuthStore _authStore;
        private readonly INavigationService<LoginViewModel> _navigationService;
        public LogoutCommand(IAuthStore authStore, INavigationService<LoginViewModel> navigationService)
        {
            this._authStore = authStore;
            this._navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            _authStore.Logout();
            _navigationService.Navigate();
        }
    }
}
