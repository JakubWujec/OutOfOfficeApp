using OutOfOfficeDomain;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestCreateCommand : CommandBase
    {
        private readonly LeaveRequestCreateViewModel viewModel;
        private readonly INavigationService<LeaveRequestListViewModel> leaveRequestListNavigationService;
        private readonly LeaveRequestService leaveRequestService;
        public LeaveRequestCreateCommand(LeaveRequestCreateViewModel viewModel, INavigationService<LeaveRequestListViewModel> navigationService, LeaveRequestService leaveRequestService) { 
            this.viewModel = viewModel;
            this.leaveRequestListNavigationService = navigationService;
            this.leaveRequestService = leaveRequestService;
        }
        public override void Execute(object? parameter)
        {
            LeaveRequest leaveRequest = new LeaveRequest()
            {
                StartDate = DateOnly.FromDateTime(viewModel.StartDate),
                EndDate = DateOnly.FromDateTime(viewModel.EndDate),
                Comment = "no reason",
            };
            leaveRequestService.CreateLeaveRequest(leaveRequest);
            leaveRequestListNavigationService.Navigate();
        }
    }
}
