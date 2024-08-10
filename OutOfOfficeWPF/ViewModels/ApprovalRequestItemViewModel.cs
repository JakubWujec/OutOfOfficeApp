using OutOfOfficeDomain;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestItemViewModel : ViewModelBase
    {
        public ApprovalRequest request { get; private set; }

        public Guid Id => this.request.Id;
        public DateOnly StartDate => this.request.LeaveRequest.StartDate;
        public DateOnly EndDate => this.request.LeaveRequest.EndDate;
        public ApprovalRequestStatus Status => this.request.Status;
        public ApprovalRequestItemViewModel(ApprovalRequest request)
        {
            this.request = request;
        }

        public override string ToString()
        {
            return $"Approval request";
        }
    }
}
