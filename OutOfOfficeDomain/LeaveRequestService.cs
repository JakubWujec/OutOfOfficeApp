using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class LeaveRequestService
    {
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests() {
            return new List<LeaveRequest>()
            {
                new LeaveRequest()
                {
                    Comment = "No reason"
                },
                new LeaveRequest()
                {
                    Comment = "Idk"
                }
            };
        }
    }
}
