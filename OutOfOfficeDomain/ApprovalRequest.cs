using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class ApprovalRequest
    {
        public Guid Id { get; set; }
        public Guid LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; } = null!;
        public string Comment { get; set; } = "";
    }
}
