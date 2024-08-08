using OutOfOfficeDomain;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestSubmitCommand : CommandBase
    {
        private readonly LeaveRequestListViewModel _viewModel;
        private readonly LeaveRequestService _leaveRequestService;
        private readonly ApprovalRequestService _approvalRequestService;
        public LeaveRequestSubmitCommand(LeaveRequestListViewModel viewModel, LeaveRequestService leaveRequestService, ApprovalRequestService approvalRequestService) { 
            this._viewModel = viewModel;
            this._leaveRequestService = leaveRequestService;
            this._approvalRequestService = approvalRequestService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            this._leaveRequestService.Submit(_viewModel.SelectedLeaveRequest.Id);
            this._approvalRequestService.CreateApprovalRequestForLeaveRequest(this._viewModel.SelectedLeaveRequest.Id);
        }

        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedLeaveRequest))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
