using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOfficeDomain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; } 
        public int OutOfOfficeBalance { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; } = new List<LeaveRequest>();
        [ForeignKey("RoleId")]
        public Role Role { get; set; }


        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return $"{FullName} (${Role.Name})";
        }
    }
}
