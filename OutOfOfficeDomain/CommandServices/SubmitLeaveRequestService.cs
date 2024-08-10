using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.Events;

namespace OutOfOfficeDomain.CommandServices
{
    public class SubmitLeaveRequestService : ICommandService<SubmitLeaveRequest>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IEventHandler<LeaveRequestSubmitted> _handler;
        public SubmitLeaveRequestService(ILeaveRequestRepository repository, IEventHandler<LeaveRequestSubmitted> handler)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            this._repository = repository;
            this._handler = handler;
        }
        public void Execute(SubmitLeaveRequest command)
        {
            var request = this._repository.GetById(command.LeaveRequestId);

            request.Submit();
            this._repository.Save(request);

            this._handler.Handle(new LeaveRequestSubmitted(request.Id));
        }
    }
}
