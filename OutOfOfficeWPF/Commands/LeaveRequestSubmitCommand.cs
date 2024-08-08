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
    public class LeaveRequestSubmitCommand : CommandBase
    {
        private readonly LeaveRequestListViewModel _viewModel;
        private readonly SubmitLeaveRequestService _submitLeaveRequestService;
        public LeaveRequestSubmitCommand(LeaveRequestListViewModel viewModel, SubmitLeaveRequestService submitLeaveRequestService) { 
            this._viewModel = viewModel;
            this._submitLeaveRequestService = submitLeaveRequestService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            var command = new SubmitLeaveRequest()
            {
                LeaveRequestId = this._viewModel.SelectedLeaveRequest.Id
            };
            this._submitLeaveRequestService.Execute(command);
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
