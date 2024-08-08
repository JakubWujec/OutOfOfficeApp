using OutOfOfficeDomain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.EventHandlers
{
    public class HRRequestEventHandler : IEventHandler<LeaveRequestSubmitted>
    {
        private readonly ApprovalRequestService _approvalRequestService;

        public HRRequestEventHandler(ApprovalRequestService approvalRequestService)
        {
            this._approvalRequestService = approvalRequestService;
        }
        public void Handle(LeaveRequestSubmitted e)
        {
            this._approvalRequestService.CreateApprovalRequestForLeaveRequest(e.LeaveRequestId);
        }
    }
}
