using OutOfOfficeDomain.Events;

namespace OutOfOfficeDomain.EventHandlers
{
    public class HRRequestEventHandler : IEventHandler<LeaveRequestSubmitted>, IEventHandler<ApprovalRequestAccepted>
    {
        private readonly ApprovalRequestService _approvalRequestService;
        private readonly LeaveRequestService _leaveRequestService;

        public HRRequestEventHandler(ApprovalRequestService approvalRequestService, LeaveRequestService leaveRequestService)
        {
            this._approvalRequestService = approvalRequestService;
            this._leaveRequestService = leaveRequestService;
        }
        public void Handle(LeaveRequestSubmitted e)
        {
            this._approvalRequestService.CreateApprovalRequestForLeaveRequest(e.LeaveRequestId);
        }

        public void Handle(ApprovalRequestAccepted e)
        {
            var approval = this._approvalRequestService.GetById(e.ApprovalRequestId);
            var leave = this._leaveRequestService.GetById(approval.LeaveRequestId);
            this._leaveRequestService.UpdateStatus(leave, LeaveRequestStatus.APPROVED); 
        }
    }
}
