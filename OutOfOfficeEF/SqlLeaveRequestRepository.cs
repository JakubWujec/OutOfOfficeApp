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
            return result;
        }


        //public void CreateLeaveRequest(LeaveRequest leaveRequest)
        //{
        //    context.LeaveRequests.Add(leaveRequest);
        //    context.SaveChanges(true);
        //}

    }
}
