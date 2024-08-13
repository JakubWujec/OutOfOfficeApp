using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeDomain.EventHandlers;
using OutOfOfficeEF;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OutOfOffice.IntegrationTests
{
    public class LeaveRequestViewModelTest
    {
        [Test]
        public void SubmittingLeaveRequest_CreatesApprovalRequest()
        {
            var dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            dbContext.Database.Migrate();


            Employee employee = CreateMockAdmin(dbContext);

            var leaveRequest = new LeaveRequest()
            {
                Comment = "comment",
                StartDate = DateOnly.FromDateTime(DateTime.Today),
                EndDate = DateOnly.FromDateTime(DateTime.Today),
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
            };

            var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
            leaveRequestRepository.Save(leaveRequest);

            var viewModel = PrepareViewModel(dbContext, leaveRequest);
            viewModel.SubmitCommand.Execute(viewModel);

            ApprovalRequest approvalRequest = dbContext.ApprovalRequests.Where(req => req.LeaveRequestId == leaveRequest.Id).First();
            LeaveRequest updatedLeaveRequest = dbContext.LeaveRequests.Where(req => req.Id == leaveRequest.Id).First();
            
            Assert.That(approvalRequest, Is.Not.Null);
            Assert.That(approvalRequest.LeaveRequestId, Is.EqualTo(leaveRequest.Id));
            Assert.That(leaveRequest.Status, Is.EqualTo(LeaveRequestStatus.SUBMITTED));
        }


        private static Employee CreateMockAdmin(OutOfOfficeDbContext dbContext)
        {
            var employeeRepository = new SqlEmployeeRepository(dbContext);
            var employee = new Employee() { Id = Guid.NewGuid(), FirstName = "Admin", LastName = "Admin", IsActive = true, OutOfOfficeBalance = 26, Position = Position.Admin };
            employeeRepository.Save(employee);
            return employee;
        }

        private LeaveRequestShowViewModel PrepareViewModel(OutOfOfficeDbContext dbContext, LeaveRequest leaveRequest)
        {
            var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
            var approvalRequestRepository = new SqlApprovalRequestRepository(dbContext);
            var leaveRequestService = new LeaveRequestService(leaveRequestRepository);
            var approvalRequestService = new ApprovalRequestService(approvalRequestRepository);
            var hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService);
            var submitLeaveRequestService = new SubmitLeaveRequestService(leaveRequestRepository, hrRequestEventHandler);
            var deleteLeaveRequestService = new DeleteLeaveRequestService(leaveRequestRepository);
            var navigationStore = new NavigationStore();
            var authStore = new AuthStore();
            var makeHomeViewModel = () => new HomeViewModel(authStore);
            var mockNavigationService = new NavigationService(navigationStore, makeHomeViewModel);

            return new LeaveRequestShowViewModel(mockNavigationService, leaveRequest, submitLeaveRequestService, deleteLeaveRequestService);
        }
    }
  
}
