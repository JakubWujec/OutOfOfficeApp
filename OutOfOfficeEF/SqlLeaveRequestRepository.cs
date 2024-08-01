using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class SqlLeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly OutOfOfficeContext context;

        public SqlLeaveRequestRepository( OutOfOfficeContext context)
        {
            this.context = context;
        }
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests()
        {
            var result = context.LeaveRequests.ToList();

            if (result.Count == 0)
            {
                context.LeaveRequests.Add(new LeaveRequest
                {
                    Comment = "No reason",
                    StartDate = DateOnly.FromDateTime(DateTime.UtcNow.Date),
                    EndDate = DateOnly.FromDateTime(DateTime.UtcNow.Date),
                });

                context.LeaveRequests.Add(new LeaveRequest
                {
                    Comment = "Idk",
                    StartDate = DateOnly.FromDateTime(DateTime.UtcNow.Date),
                    EndDate = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(2)),
                });

                context.SaveChanges();

                result = context.LeaveRequests.ToList();
            }

            return result;
        }
    }
}
