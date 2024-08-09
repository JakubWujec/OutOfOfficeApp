using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Tests
{
    public partial class LeaveRequestServiceTests
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
    }
}
