using OutOfOfficeDomain;
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
        private readonly ObservableCollection<LeaveRequestItemViewModel> _leaveRequests;
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests => _leaveRequests;
        public ICommand NavigateCommand { get; }
        public LeaveRequestListViewModel(LeaveRequestService leaveRequestService, INavigationService createLeaveRequestNavigationService)
        {
            _leaveRequests = new ObservableCollection<LeaveRequestItemViewModel>();
            NavigateCommand = new NavigateCommand(createLeaveRequestNavigationService);

            UpdateLeaveRequests(leaveRequestService.GetCurrentLeaveRequests());
        }

        public void UpdateLeaveRequests(IEnumerable<LeaveRequest> leaveRequests)
        {
            LeaveRequests.Clear();
            foreach (var item in leaveRequests)
            {
                LeaveRequests.Add(new LeaveRequestItemViewModel(
                    item.Comment,
                    item.StartDate,
                    item.EndDate,
                    item.Id
                ));
            }
        }
    }
}
