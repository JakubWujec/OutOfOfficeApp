using OutOfOfficeDomain.CommandServices;
using OutOfOfficeDomain.Events;
using OutOfOfficeDomain.Exceptions;
using OutOfOfficeDomain.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain.Tests.CommandServices
{
    public class LeaveRequestServiceTests
    {
        [Test]
        public void Create_WhenEndDateBeforeStartDate_WillThrow()
        {
            var repository = new StubLeaveRequestRepository();
            var service = new LeaveRequestService(repository);
            var employee = CreateEmployee(26);
            var leaveRequest = new LeaveRequest()
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
            };

            // Act
            TestDelegate action = () => service.CreateLeaveRequest(employee, leaveRequest);

            // Assert
            Assert.Throws<InvalidLeaveRequestDateOnlyRangeException>(action);
        }

        [Test]
        public void Create_WhenEmployeeDoesNotHaveEnoughBalance_WillThrow()
        {
            var repository = new StubLeaveRequestRepository();
            var service = new LeaveRequestService(repository);
            var employeeBalance = 26;
            var employee = CreateEmployee(employeeBalance);
            var leaveRequest = new LeaveRequest()
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(employeeBalance + 100)),
            };

            // Act
            TestDelegate action = () => service.CreateLeaveRequest(employee, leaveRequest);

            // Assert
            Assert.Throws<InsufficientBalanceException>(action);
        }

        private Employee CreateEmployee(int outOfOfficeBalance)
        {
            return new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test1",
                LastName = "Test2",
                OutOfOfficeBalance = outOfOfficeBalance
            };
        }
    }
}
