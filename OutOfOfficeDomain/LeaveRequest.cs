namespace OutOfOfficeDomain
{
    public enum LeaveRequestStatus
    {
        NEW,
        SUBMITTED,
        CANCELLED,
        APPROVED,
        REJECTED,
    }
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Comment { get; set; } = String.Empty;
        public Guid EmployeeId { get; set; } // Required foreign key property
        public Employee Employee { get; set; } = null!; // Required reference navigation to principal
        public LeaveRequestStatus Status { get;  set; } = LeaveRequestStatus.NEW;

        public int DurationInDays => EndDate.DayNumber - StartDate.DayNumber;

        public void Cancel()
        {
            this.Status = LeaveRequestStatus.CANCELLED;
        }

        public void Submit()
        {
            this.Status = LeaveRequestStatus.SUBMITTED;
        }

        public void MarkApproved()
        {
            this.Status = LeaveRequestStatus.APPROVED;
        }

        public void MarkRejected()
        {
            this.Status = LeaveRequestStatus.REJECTED;
        }
    }
}
