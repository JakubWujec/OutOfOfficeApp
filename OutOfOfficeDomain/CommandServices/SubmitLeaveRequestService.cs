using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.CommandServices
{
    public class SubmitLeaveRequestService : ICommandService<SubmitLeaveRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEventHandler<LeaveRequestSubmitted> _handler;
        public SubmitLeaveRequestService(ILeaveRequestRepository leaveRequestRepository, IEventHandler<LeaveRequestSubmitted> handler)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._handler = handler;

        }
        public void Execute(SubmitLeaveRequest command)
        {
            var request = this._leaveRequestRepository.GetById(command.LeaveRequestId);
            if (request == null)
            {
                throw new ArgumentException();
            }
            this._handler.Handle(new LeaveRequestSubmitted(request.Id));
        }
    }
}
