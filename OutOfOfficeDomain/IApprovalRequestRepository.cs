using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public interface IApprovalRequestRepository
    {
        public void Save(ApprovalRequest approvalRequest);
        public IEnumerable<ApprovalRequest> GetAll();
    }
}
