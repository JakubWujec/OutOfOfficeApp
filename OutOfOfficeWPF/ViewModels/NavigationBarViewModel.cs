using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class NavigationButtonViewModel
    {
        public string Content { get; }
        public ICommand Command { get; }
        public bool IsVisible { get; set; } 

        public NavigationButtonViewModel(string content, ICommand command, bool isVisible = true)
        {
            Content = content;
            Command = command;
            IsVisible = isVisible;
        }
    }
    public class NavigationBarViewModel
    {
        private readonly IAuthStore authStore;
        public ObservableCollection<NavigationButtonViewModel> NavigationButtons { get; }
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
            NavigationButtons = new ObservableCollection<NavigationButtonViewModel>
            {
                new NavigationButtonViewModel("Home", new NavigateCommand(homeNavigationService), authStore.IsLoggedIn),
                new NavigationButtonViewModel("Make leave request", new NavigateCommand(createLeaveRequestNavigationService), authStore.IsLoggedIn),
                new NavigationButtonViewModel("Leave requests", new NavigateCommand(leaveRequestListNavigationService), authStore.IsLoggedIn),
                new NavigationButtonViewModel("Approval requests", new NavigateCommand(approvalRequestListNavigationService), authStore.IsLoggedIn),
                new NavigationButtonViewModel("Logout", new LogoutCommand(authStore, loginNavigationService), authStore.IsLoggedIn)
            };

            this.authStore = authStore;
            this.authStore.CurrentEmployeeChanged += AuthStore_CurrentEmployeeChanged;
        }

        private void ConfigureNavigationButtons()
        {
            if (!authStore.IsLoggedIn)
            {
                foreach (var item in NavigationButtons)
                {
                    item.IsVisible = false;
                }
            } else
            {
                foreach (var item in NavigationButtons)
                {
                    item.IsVisible = true;
                }
            }
        }
        private void AuthStore_CurrentEmployeeChanged()
        {
            ConfigureNavigationButtons();
        }
    }
}
