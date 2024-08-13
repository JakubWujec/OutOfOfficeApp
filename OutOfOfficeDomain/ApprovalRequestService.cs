namespace OutOfOfficeDomain
{
    public class ApprovalRequestService
    {
        private readonly IApprovalRequestRepository _approvalRequestRepository;
        public ApprovalRequestService(IApprovalRequestRepository approvalRequestRepository)
        {
            this._approvalRequestRepository = approvalRequestRepository;
        }

        public IEnumerable<ApprovalRequest> GetApprovalRequests()
        {
            return _approvalRequestRepository.GetAll();
        }

        public ApprovalRequest GetById(Guid id)
        {
            return _approvalRequestRepository.GetById(id);
        }

        public void CreateApprovalRequestForLeaveRequest(Guid leaveRequestId)
        {
            var request = new ApprovalRequest()
            {
                LeaveRequestId = leaveRequestId
            };
            this._approvalRequestRepository.Save(request);
        }
    }
}
