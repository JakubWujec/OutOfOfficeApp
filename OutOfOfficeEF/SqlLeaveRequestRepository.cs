using Microsoft.EntityFrameworkCore;
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

        public void Save(LeaveRequest leaveRequest)
        {
            if (this.context.IsNew(leaveRequest))
            {
                this.context.LeaveRequests.Add(leaveRequest);
            }
            this.context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            context.LeaveRequests.Where(lr => lr.Id == id).ExecuteDelete();
        }
        public LeaveRequest? GetById(Guid id)
        {
            return context.LeaveRequests.Find(id);
        }

    }
}
