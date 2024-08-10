namespace OutOfOfficeDomain
{
    public interface IApprovalRequestRepository
    {
        public void Save(ApprovalRequest approvalRequest);
        public ApprovalRequest GetById(Guid id);
        public IEnumerable<ApprovalRequest> GetAll();
    }
}
