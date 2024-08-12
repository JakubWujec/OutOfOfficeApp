using OutOfOfficeDomain;

namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestItemViewModel : ViewModelBase
    {
        public string Comment => _leaveRequest.Comment;
        public DateOnly StartDate => _leaveRequest.StartDate;
        public DateOnly EndDate => _leaveRequest.EndDate;
        public Guid Id => _leaveRequest.Id;
        public LeaveRequest _leaveRequest { get; init; }
        public LeaveRequest LeaveRequest => _leaveRequest;

        public LeaveRequestItemViewModel(LeaveRequest leaveRequest)
        {
            this._leaveRequest = leaveRequest;
        }

        public override string ToString()
        {
            return $"{this.Comment}";
        }
    }
}
