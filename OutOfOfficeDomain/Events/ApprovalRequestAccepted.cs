using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Events
{
    public class ApprovalRequestAccepted
    {
        public readonly Guid ApprovalRequestId;
        public ApprovalRequestAccepted(Guid approvalRequestId)
        {
            this.ApprovalRequestId = approvalRequestId;
        }
    }   
}
