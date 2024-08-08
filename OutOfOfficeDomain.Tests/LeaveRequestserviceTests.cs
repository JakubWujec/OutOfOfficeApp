using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Tests
{
    public class LeaveRequestServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetCurrentLeaveRequestsWillReturnInstance()
        {
            // Arrange
            var service = new LeaveRequestService(new StubLeaveRequestRepository());

            // Act
            var result = service.GetCurrentLeaveRequests();

            // Assert
            Assert.NotNull(result);
        }

        private class StubLeaveRequestRepository : ILeaveRequestRepository
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

            public IEnumerable<LeaveRequest> GetCurrentLeaveRequests() => this.leaveRequests.AsEnumerable();


        }
    }
}
