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

        public void Save(ApprovalRequest approvalRequest)
        {
            context.ApprovalRequests.Add(approvalRequest);
            context.SaveChanges(true);
        }
    }
}
