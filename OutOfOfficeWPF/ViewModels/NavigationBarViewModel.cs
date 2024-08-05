using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace OutOfOfficeWPF.ViewModels
{
    public class NavigationBarViewModel
    {
        private readonly IAuthStore authStore;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateMakeLeaveRequestCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand LogoutCommand { get; }
        public bool IsLoggedIn => authStore.IsLoggedIn;

        public NavigationBarViewModel(
            INavigationService<HomeViewModel> homeNavigationService,
            INavigationService<LeaveRequestCreateViewModel> createLeaveRequestNavigationService,
            INavigationService<LoginViewModel> loginNavigationService,
            IAuthStore authStore
        )
        {
            this.NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            this.NavigateMakeLeaveRequestCommand = new NavigateCommand<LeaveRequestCreateViewModel>(createLeaveRequestNavigationService);
            this.NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            this.authStore = authStore;
            this.LogoutCommand = new LogoutCommand(authStore, loginNavigationService);
            
        }
    }
}
