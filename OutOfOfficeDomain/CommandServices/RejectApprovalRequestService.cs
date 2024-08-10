using OutOfOfficeDomain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.CommandServices
{
    public class RejectApprovalRequestService
    {
        private readonly IApprovalRequestRepository _repository;
        public RejectApprovalRequestService(IApprovalRequestRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this._repository = repository;
        }

        public void Execute(RejectApprovalRequest command)
        {
            var request = this._repository.GetById(command.ApprovalRequestId);

            request.Reject();
            this._repository.Save(request);
        }
    }
}
