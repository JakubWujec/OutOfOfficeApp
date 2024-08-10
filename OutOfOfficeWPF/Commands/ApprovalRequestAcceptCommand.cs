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
    public class ApprovalRequestAcceptCommand : CommandBase
    {
        private readonly ApprovalRequestShowViewModel _viewModel;
        private readonly AcceptApprovalRequestService _acceptApprovalService;
        public ApprovalRequestAcceptCommand(ApprovalRequestShowViewModel viewModel, AcceptApprovalRequestService acceptApprovalService) { 
            this._viewModel = viewModel;
            this._acceptApprovalService = acceptApprovalService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            var command = new AcceptApprovalRequest()
            {
                ApprovalRequestId = this._viewModel.SelectedRequest.Id
            };
            this._acceptApprovalService.Execute(command);
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
