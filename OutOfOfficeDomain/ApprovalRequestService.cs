using OutOfOfficeDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class ApprovalRequestService
    {
        private readonly IApprovalRequestRepository _approvalRequestRepository;
        public ApprovalRequestService(IApprovalRequestRepository approvalRequestRepository)
        {
            this._approvalRequestRepository = approvalRequestRepository;
        }

        public void CreateApprovalRequestForLeaveRequest(Guid leaveRequestId)
        {
            var request = new ApprovalRequest()
            {
                LeaveRequestId = leaveRequestId
            };
            this._approvalRequestRepository.Save(request);
        }
    }
}
