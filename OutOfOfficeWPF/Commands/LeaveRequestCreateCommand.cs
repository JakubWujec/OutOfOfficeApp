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
        private readonly NavigationService navigationService;
        public LeaveRequestCreateCommand(LeaveRequestCreateViewModel viewModel, NavigationService navigationService) { 
            this.viewModel = viewModel;
            this.navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            LeaveRequest leaveRequest = new LeaveRequest()
            {
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                Comment = "no reason",
            };
            navigationService.Navigate();
        }
    }
}
