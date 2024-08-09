using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class SqlApprovalRequestRepository : IApprovalRequestRepository
    {
        private readonly OutOfOfficeContext context;

        public SqlApprovalRequestRepository(OutOfOfficeContext context)
        {
            this.context = context;
        }

        public IEnumerable<ApprovalRequest> GetAll()
        {
            return context.ApprovalRequests.Include(x => x.LeaveRequest).ToList();
        }

        public ApprovalRequest? GetById(Guid id)
        {
            return context.ApprovalRequests.Find(id);
        }

        public void Save(ApprovalRequest approvalRequest)
        {
            if (this.context.IsNew(approvalRequest))
            {
                this.context.ApprovalRequests.Add(approvalRequest);
            }
            context.SaveChanges(true);
        }
        
    }
}
