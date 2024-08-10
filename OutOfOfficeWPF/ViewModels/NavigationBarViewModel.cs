using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class NavigationBarViewModel
    {
        private readonly IAuthStore authStore;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateMakeLeaveRequestCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateLeaveRequestListCommand { get; }
        public ICommand LogoutCommand { get; }

        public ICommand NavigateApprovalRequestListCommand { get; }
        public bool IsLoggedIn => authStore.IsLoggedIn;

        public NavigationBarViewModel(
            INavigationService homeNavigationService,
            INavigationService createLeaveRequestNavigationService,
            INavigationService loginNavigationService,
            INavigationService leaveRequestListNavigationService,
            INavigationService approvalRequestListNavigationService,
            IAuthStore authStore
        )
        {
            this.NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            this.NavigateMakeLeaveRequestCommand = new NavigateCommand(createLeaveRequestNavigationService);
            this.NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            this.NavigateLeaveRequestListCommand = new NavigateCommand(leaveRequestListNavigationService);
            this.NavigateApprovalRequestListCommand = new NavigateCommand(approvalRequestListNavigationService);
            this.authStore = authStore;
            this.LogoutCommand = new LogoutCommand(authStore, loginNavigationService);

        }
    }
}
