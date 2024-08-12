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

namespace OutOfOffice.IntegrationTests
{
    public class LeaveRequestViewModelTest
    {
        //[Test]
        //public void SubmittingLeaveRequest_CreatesApprovalRequest()
        //{
        //    var dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
        //    dbContext.Database.Migrate();

        //    var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
        //    var approvalRequestRepository = new SqlApprovalRequestRepository(dbContext);
        //    var leaveRequestService = new LeaveRequestService(leaveRequestRepository);
        //    var approvalRequestService = new ApprovalRequestService(approvalRequestRepository);
        //    var hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService);
        //    var submitLeaveRequestService = new SubmitLeaveRequestService(leaveRequestRepository, hrRequestEventHandler);
        //    var navigationStore = new NavigationStore();
        //    var authStore = new AuthStore();
        //    var makeHomeViewModel = () => new HomeViewModel(authStore);
        //    var mockNavigationService = new NavigationService(navigationStore, makeHomeViewModel);


        //    var leaveRequest = new LeaveRequest();
        //    var viewModel = new LeaveRequestListViewModel(leaveRequestService, submitLeaveRequestService, mockNavigationService);

        //    var guid = Guid.NewGuid();
        //    viewModel.SelectedLeaveRequest = new LeaveRequestItemViewModel("comment", DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today), guid);
        //    viewModel.SubmitSelectedCommand.Execute(viewModel);

        //    ApprovalRequest approvalRequest = dbContext.ApprovalRequests.Where(req => req.LeaveRequestId == guid).First();

        //    Assert.That(approvalRequest, Is.Not.Null);
        //}


        //private LeaveRequestListViewModel PrepareViewModel(OutOfOfficeDbContext dbContext)
        //{
        //    var leaveRequestRepository = new SqlLeaveRequestRepository(dbContext);
        //    var approvalRequestRepository = new SqlApprovalRequestRepository(dbContext);
        //    var leaveRequestService = new LeaveRequestService(leaveRequestRepository);
        //    var approvalRequestService = new ApprovalRequestService(approvalRequestRepository);
        //    var hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService);
        //    var submitLeaveRequestService = new SubmitLeaveRequestService(leaveRequestRepository, hrRequestEventHandler);
        //    var navigationStore = new NavigationStore();
        //    var authStore = new AuthStore();
        //    var makeHomeViewModel = () => new HomeViewModel(authStore);
        //    var mockNavigationService = new NavigationService(navigationStore, makeHomeViewModel);

        //    return new LeaveRequestListViewModel(leaveRequestService, submitLeaveRequestService, mockNavigationService);
        //}
    }
  
}
