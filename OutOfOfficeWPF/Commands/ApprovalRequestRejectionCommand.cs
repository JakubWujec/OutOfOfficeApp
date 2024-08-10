using OutOfOfficeDomain;
using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class ApprovalRequestRejectCommand : CommandBase
    {
        private readonly ApprovalRequestShowViewModel _viewModel;
        private readonly RejectApprovalRequestService _rejectApprovalService;
        public ApprovalRequestRejectCommand(ApprovalRequestShowViewModel viewModel, RejectApprovalRequestService rejectApprovalService) { 
            this._viewModel = viewModel;
            this._rejectApprovalService = rejectApprovalService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            var command = new RejectApprovalRequest()
            {
                ApprovalRequestId = this._viewModel.SelectedRequest.Id
            };
            this._rejectApprovalService.Execute(command);
        }

        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedRequest))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
