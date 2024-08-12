using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.CommandServices
{
    public class DeleteLeaveRequestService: ICommandService<DeleteLeaveRequest>
    {
        private readonly ILeaveRequestRepository _repository;
        
        public DeleteLeaveRequestService(ILeaveRequestRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this._repository = repository;
        
        }
        public void Execute(DeleteLeaveRequest command)
        {   
            this._repository.DeleteById(command.LeaveRequestId);
        }
    }
}
