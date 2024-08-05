using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Exceptions
{
    public class InvalidLeaveRequestDateOnlyRangeException: Exception
    {
        public LeaveRequest LeaveRequest { get; }

        public InvalidLeaveRequestDateOnlyRangeException(LeaveRequest leaveRequest)
        {
            LeaveRequest = leaveRequest;
        }
    }
}
