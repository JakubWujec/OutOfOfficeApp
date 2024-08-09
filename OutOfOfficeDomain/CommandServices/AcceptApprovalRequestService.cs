using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.CommandServices
{
    public class AcceptApprovalRequestService : ICommandService<AcceptApprovalRequest>
    {
        private readonly IApprovalRequestRepository _repository;


        public AcceptApprovalRequestService(IApprovalRequestRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this._repository = repository;
        }

        public void Execute(AcceptApprovalRequest command)
        {
            var request = this._repository.GetById(command.ApprovalRequestId);

            request.Accept();
            this._repository.Save(request);

            // this._handler.Handle(new LeaveRequestSubmitted(request.Id));
        }
    }
}
