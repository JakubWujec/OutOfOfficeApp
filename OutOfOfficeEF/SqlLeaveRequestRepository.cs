using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;

namespace OutOfOfficeEF
{
    public class SqlLeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly OutOfOfficeDbContext context;

        public SqlLeaveRequestRepository(OutOfOfficeDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<LeaveRequest> GetAll()
        {
            var result = context.LeaveRequests.ToList();
            return result;
        }

        public void Save(LeaveRequest leaveRequest)
        {
            if (this.context.IsNew(leaveRequest))
            {
                this.context.LeaveRequests.Add(leaveRequest);
            }
            this.context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            context.LeaveRequests.Where(lr => lr.Id == id).ExecuteDelete();
        }
        public LeaveRequest? GetById(Guid id)
        {
            return context.LeaveRequests.Find(id);
        }

    }
}
