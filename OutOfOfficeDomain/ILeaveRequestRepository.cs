namespace OutOfOfficeDomain
{
    public interface ILeaveRequestRepository
    {
        public IEnumerable<LeaveRequest> GetAll();
        public void Save(LeaveRequest leaveRequest);
        public void DeleteById(Guid id);
        public LeaveRequest? GetById(Guid id);
    }
}
