using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestListViewModel: ViewModelBase
    {
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests { get; }
        public ICommand NavigateToCommand { get; }
        public LeaveRequestListViewModel(IEnumerable<LeaveRequestItemViewModel> leaveRequests, INavigationService createLeaveRequestNavigationService)
        {
            this.LeaveRequests = new ObservableCollection<LeaveRequestItemViewModel>(leaveRequests);
            NavigateToCommand = new NavigateCommand(createLeaveRequestNavigationService);
        }
    }
}
