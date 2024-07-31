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

            LeaveRequestService service = new LeaveRequestService();
            IEnumerable<LeaveRequest> requests = service.GetCurrentLeaveRequests();

            foreach (var request in requests)
            {
                LeaveRequests.Add(
                    new LeaveRequestItemViewModel(request.Comment)
                );
            }
            
       
        }
    }
}
