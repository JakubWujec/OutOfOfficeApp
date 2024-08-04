using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
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
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateMakeLeaveRequestCommand { get; }
        public NavigationBarViewModel(
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<LeaveRequestCreateViewModel> createLeaveRequestNavigationService
        ) {
            this.NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            this.NavigateMakeLeaveRequestCommand = new NavigateCommand<LeaveRequestCreateViewModel>(createLeaveRequestNavigationService);
        }
    }
}
