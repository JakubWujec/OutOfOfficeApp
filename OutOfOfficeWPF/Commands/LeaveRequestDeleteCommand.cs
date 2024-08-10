using OutOfOfficeDomain;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestDeleteCommand : CommandBase
    {
        private readonly LeaveRequestListViewModel _viewModel;
        private readonly LeaveRequestService _leaveRequestService;

        public LeaveRequestDeleteCommand(LeaveRequestListViewModel viewModel, LeaveRequestService leaveRequestService)
        {
            this._viewModel = viewModel;
            this._leaveRequestService = leaveRequestService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedLeaveRequest != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _leaveRequestService.DeleteById(_viewModel.SelectedLeaveRequest.Id);
            _viewModel.LeaveRequests.Remove(_viewModel.SelectedLeaveRequest);
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
