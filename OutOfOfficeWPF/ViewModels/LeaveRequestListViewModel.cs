using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestListViewModel: ViewModelBase
    {
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests { get; }
        public LeaveRequestListViewModel(IEnumerable<LeaveRequestItemViewModel> leaveRequests)
        {
            this.LeaveRequests = new ObservableCollection<LeaveRequestItemViewModel>(leaveRequests);
        }
    }
}
