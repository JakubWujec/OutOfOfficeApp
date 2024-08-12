using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OutOfOfficeDomain;

namespace OutOfOfficeWPF.ViewModels
{
    public class NavigationButtonViewModel
    {
   
        public string Content { get; }
        public ICommand Command { get; }
        public bool IsVisible { get; } = false;
        public Func<bool> CanNavigate { get; }

        public NavigationButtonViewModel(string content, ICommand command, Func<bool> canNavigate)
        {
            Content = content;
            Command = command;
            CanNavigate = canNavigate;
            IsVisible = canNavigate();
        }
        public NavigationButtonViewModel Copy()
        {
            return new NavigationButtonViewModel(Content, Command, CanNavigate);
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
            INavigationService createEmployeeNavigationService,
            IAuthStore authStore
        )
        {
            this.authStore = authStore;
            this.authStore.CurrentEmployeeChanged += AuthStore_CurrentEmployeeChanged;

            var forLoggedIn = () => authStore.IsLoggedIn;
            var forAdminOrHr = () => authStore.IsInPosition(Position.HRManager) || authStore.IsInPosition(Position.Admin);

            NavigationButtons = new ObservableCollection<NavigationButtonViewModel>
            {
                // logged in
                new NavigationButtonViewModel("Home", new NavigateCommand(homeNavigationService), forLoggedIn),
                new NavigationButtonViewModel("Make leave request", new NavigateCommand(createLeaveRequestNavigationService), forLoggedIn),
            
                new NavigationButtonViewModel("Leave requests", new NavigateCommand(leaveRequestListNavigationService), forAdminOrHr),
                new NavigationButtonViewModel("Approval requests", new NavigateCommand(approvalRequestListNavigationService), forAdminOrHr),
                new NavigationButtonViewModel("Add new user", new NavigateCommand(createEmployeeNavigationService), forAdminOrHr),

                new NavigationButtonViewModel("Logout", new LogoutCommand(authStore, loginNavigationService), forLoggedIn),
            };
        }

        private void ConfigureNavigationButtons()
        {
            var tmp = new ObservableCollection<NavigationButtonViewModel>(NavigationButtons);
            NavigationButtons.Clear();

            foreach(var button in tmp)
            {
                NavigationButtons.Add(button.Copy());
            }
            
            tmp.Clear();
        }

        private void AuthStore_CurrentEmployeeChanged()
        {
            ConfigureNavigationButtons();
        }
    }
}
