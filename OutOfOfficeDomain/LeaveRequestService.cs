using OutOfOfficeDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class LeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository; 
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository) {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests() {
            return _leaveRequestRepository.GetCurrentLeaveRequests();
        }

        public void CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            if (leaveRequest.StartDate > leaveRequest.EndDate)
            {
                throw new InvalidLeaveRequestDateOnlyRangeException(leaveRequest);
            }
            _leaveRequestRepository.CreateLeaveRequest(leaveRequest);
        }

        public void DeleteById(Guid guid)
        {
            _leaveRequestRepository.DeleteById(guid);
        }

        public void Submit(Guid guid)
        {
            // get leave request
            // change status to submitted
            // create new approval request(s)
            var leaveRequest = _leaveRequestRepository.GetById(guid);
            

        }
    }
}
