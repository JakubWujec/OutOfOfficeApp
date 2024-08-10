namespace OutOfOfficeDomain
{
    public enum ApprovalRequestStatus
    {
        NEW,
        REJECTED,
        ACCEPTED
    }
    public class ApprovalRequest
    {
        public Guid Id { get; set; }
        public Guid LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; } = null!;
        public string Comment { get; set; } = "";

        public ApprovalRequestStatus Status { get; private set; } = ApprovalRequestStatus.NEW;

        public void Accept()
        {
            this.Status = ApprovalRequestStatus.ACCEPTED;
        }

        public void Reject()
        {
            this.Status = ApprovalRequestStatus.REJECTED;
        }
    }
}
