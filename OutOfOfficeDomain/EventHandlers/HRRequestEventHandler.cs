using OutOfOfficeDomain.Events;

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
