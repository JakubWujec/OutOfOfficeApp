using OutOfOfficeDomain.Exceptions;

namespace OutOfOfficeDomain
{
    public class LeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests()
        {
            return _leaveRequestRepository.GetAll();
        }

        public void CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            if (leaveRequest.StartDate > leaveRequest.EndDate)
            {
                throw new InvalidLeaveRequestDateOnlyRangeException(leaveRequest);
            }
            _leaveRequestRepository.Save(leaveRequest);
        }

        public void DeleteById(Guid guid)
        {
            _leaveRequestRepository.DeleteById(guid);
        }
    }
}
