using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; } // Required foreign key property
        public Employee Employee { get; set; } = null!; // Required reference navigation to principal
    }
}
