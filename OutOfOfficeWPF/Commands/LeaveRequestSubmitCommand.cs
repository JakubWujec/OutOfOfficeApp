using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestSubmitCommand : CommandBase
    {
        private readonly LeaveRequestShowViewModel _viewModel;
        private readonly SubmitLeaveRequestService _submitLeaveRequestService;
        public LeaveRequestSubmitCommand(LeaveRequestShowViewModel viewModel, SubmitLeaveRequestService submitLeaveRequestService)
        {
            this._viewModel = viewModel;
            this._submitLeaveRequestService = submitLeaveRequestService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            var command = new SubmitLeaveRequest()
            {
                LeaveRequestId = this._viewModel.SelectedRequest.Id
            };
            this._submitLeaveRequestService.Execute(command);
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
