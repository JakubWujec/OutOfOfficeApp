using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Events
{
    public class LeaveRequestSubmitted
    {
        
        public readonly Guid LeaveRequestId;

        public LeaveRequestSubmitted(Guid leaveRequestId)
        {
            this.LeaveRequestId = leaveRequestId;
        }
       
    }
}
