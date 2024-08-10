using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;

namespace OutOfOfficeWPF.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly IAuthStore _authStore;
        private readonly INavigationService _navigationService;
        public LogoutCommand(IAuthStore authStore, INavigationService navigationService)
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
