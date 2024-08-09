namespace OutOfOfficeDomain.Tests
{
   
    public class StubLeaveRequestRepository : ILeaveRequestRepository
    {
        public List<LeaveRequest> leaveRequests { get; set; } = new List<LeaveRequest>();
        public void Save(LeaveRequest leaveRequest)
        {
            this.leaveRequests.Add(leaveRequest);
        }

        public void DeleteById(Guid id)
        {
            var request = this.GetById(id);
            if (request != null)
            {
                this.leaveRequests.Remove(request);
            }
        }

        public LeaveRequest? GetById(Guid id)
        {
            return this.leaveRequests.First(lr => lr.Id == id);
        }

        public IEnumerable<LeaveRequest> GetAll() => this.leaveRequests.AsEnumerable();


    }
    
}
