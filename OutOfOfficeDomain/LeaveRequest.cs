namespace OutOfOfficeDomain
{
    public enum LeaveRequestStatus
    {
        NEW,
        SUBMITTED,
        CANCELLED
    }
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; } // Required foreign key property
        public Employee Employee { get; set; } = null!; // Required reference navigation to principal
        public LeaveRequestStatus Status { get; private set; } = LeaveRequestStatus.NEW;


        public void Cancel()
        {
            this.Status = LeaveRequestStatus.CANCELLED;
        }

        public void Submit()
        {
            this.Status = LeaveRequestStatus.SUBMITTED;
        }
    }
}
