using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class LeaveRequestService
    {
        private readonly ILeaveRequestRepository repository; 
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository) {
            repository = leaveRequestRepository;
        }
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests() {
            return repository.GetCurrentLeaveRequests();
        }
    }
}
