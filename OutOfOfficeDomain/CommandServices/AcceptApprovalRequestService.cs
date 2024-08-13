using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.Events;

namespace OutOfOfficeDomain.CommandServices
{
    public class AcceptApprovalRequestService : ICommandService<AcceptApprovalRequest>
    {
        private readonly IApprovalRequestRepository _repository;
        private readonly IEventHandler<ApprovalRequestAccepted> _handler;

        public AcceptApprovalRequestService(IApprovalRequestRepository repository, IEventHandler<ApprovalRequestAccepted> handler)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            this._handler = handler;
            this._repository = repository;
        }

        public void Execute(AcceptApprovalRequest command)
        {
            var request = this._repository.GetById(command.ApprovalRequestId);

            request.Accept();
            this._repository.Save(request);

            this._handler.Handle(new ApprovalRequestAccepted(request.Id));
        }
    }
}
