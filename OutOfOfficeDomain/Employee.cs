namespace OutOfOfficeDomain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; } = new List<LeaveRequest>();

        public string FullName => $"{FirstName} {LastName}";
    }
}
