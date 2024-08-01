using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class SqlLeaveRequestRepository : ILeaveRequestRepository
    {
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests()
        {
            //TODO replace with db query
            return new List<LeaveRequest>()
            {
                new LeaveRequest()
                {
                    Comment = "No reason"
                },
                new LeaveRequest()
                {
                    Comment = "Idk"
                },
                 new LeaveRequest()
                {
                    Comment = "Joe"
                }
            };
        }
    }
}
