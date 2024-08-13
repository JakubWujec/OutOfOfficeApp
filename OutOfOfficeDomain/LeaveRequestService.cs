using OutOfOfficeDomain.Exceptions;
using System.Data;

namespace OutOfOfficeDomain
{
    public class LeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public IEnumerable<LeaveRequest> GetAll()
        {
            return _leaveRequestRepository.GetAll();
        }

        public LeaveRequest GetById (Guid id)
        {
            return _leaveRequestRepository.GetById(id);
        }

        public void CreateLeaveRequest(Employee employee, LeaveRequest leaveRequest)
        {
            leaveRequest.Employee = employee;

            if (leaveRequest.StartDate > leaveRequest.EndDate)
            {
                throw new InvalidLeaveRequestDateOnlyRangeException(leaveRequest);
            }

            if(leaveRequest.DurationInDays > leaveRequest.Employee.OutOfOfficeBalance)
            {
                throw new InsufficientBalanceException();
            }

            _leaveRequestRepository.Save(leaveRequest);
        }

        public void UpdateStatus(LeaveRequest leaveRequest, LeaveRequestStatus status)
        {
            leaveRequest.Status = status;
            _leaveRequestRepository.Save(leaveRequest);
        }

        public void DeleteById(Guid guid)
        {
            _leaveRequestRepository.DeleteById(guid);
        }
    }
}
