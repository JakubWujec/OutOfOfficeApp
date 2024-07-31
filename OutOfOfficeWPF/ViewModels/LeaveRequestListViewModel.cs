using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeDomain;

namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestListViewModel
    {
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests { get; set; }
        public LeaveRequestListViewModel()
        {
            LeaveRequests = new ObservableCollection<LeaveRequestItemViewModel>();

            LeaveRequests.Add(new LeaveRequestItemViewModel("No reason"));
        }
    }
}
