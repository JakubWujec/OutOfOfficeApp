using OutOfOfficeDomain;
using OutOfOfficeEF;
using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.ViewModels;
using OutOfOfficeDomain.EventHandlers;

namespace OutOfOffice.IntegrationTests
{
    public class AcceptingApprovalRequestsTests
    {
        private OutOfOfficeDbContext dbContext;
        private ApprovalRequest approvalRequest;
        private LeaveRequest leaveRequest;
        private ApprovalRequestShowViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            dbContext.Database.Migrate();

            var employee = CreateMockAdmin(dbContext);

            leaveRequest = new LeaveRequest()
            {
                Comment = "comment",
                StartDate = DateOnly.FromDateTime(DateTime.Today),
                EndDate = DateOnly.FromDateTime(DateTime.Today),
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
            };
            var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
            leaveRequestRepository.Save(leaveRequest);

            approvalRequest = new ApprovalRequest()
            {
                Id = Guid.NewGuid(),
                LeaveRequestId = leaveRequest.Id,
            };
            var approvalRequestRepository = new SqlApprovalRequestRepository(dbContext);
            approvalRequestRepository.Save(approvalRequest);

            viewModel = PrepareViewModel(dbContext, approvalRequest);
            viewModel.ApprovalRequestAcceptCommand.Execute(null);
        }

        [Test]
        public void AcceptingApprovalRequest_MarkApprovalRequestAsAccepted()
        {
            ApprovalRequest updatedApprovalRequest = dbContext.ApprovalRequests
                .Where(req => req.Id == approvalRequest.Id)
                .First();

            Assert.That(updatedApprovalRequest.Status, Is.EqualTo(ApprovalRequestStatus.ACCEPTED));
        }

        [Test]
        public void AcceptingApprovalRequest_MarkLeaveRequestAsApproved()
        {
            LeaveRequest updatedLeaveRequest = dbContext.LeaveRequests
                .Where(req => req.Id == leaveRequest.Id)
                .First();

            Assert.That(updatedLeaveRequest.Status, Is.EqualTo(LeaveRequestStatus.APPROVED));
        }


        private static Employee CreateMockAdmin(OutOfOfficeDbContext dbContext)
        {
            var employeeRepository = new SqlEmployeeRepository(dbContext);
            var employee = new Employee() { Id = Guid.NewGuid(), FirstName = "Admin", LastName = "Admin", IsActive = true, OutOfOfficeBalance = 26, Position = Position.Admin };
            employeeRepository.Save(employee);
            return employee;
        }

        private ApprovalRequestShowViewModel PrepareViewModel(OutOfOfficeDbContext dbContext, ApprovalRequest approvalRequest)
        {
            var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
            var approvalRequestRepository = new SqlApprovalRequestRepository(dbContext);
            var approvalRequestService = new ApprovalRequestService(approvalRequestRepository);
            var leaveRequestService = new LeaveRequestService(leaveRequestRepository);
            var hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService, leaveRequestService);
            var acceptApprovalRequestService = new AcceptApprovalRequestService(approvalRequestRepository, hrRequestEventHandler);
            var rejectApprovalRequestService = new RejectApprovalRequestService(approvalRequestRepository);
            var mockNavigationService = new MockNavigationService();

            return new ApprovalRequestShowViewModel(mockNavigationService, acceptApprovalRequestService, rejectApprovalRequestService, approvalRequest);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
