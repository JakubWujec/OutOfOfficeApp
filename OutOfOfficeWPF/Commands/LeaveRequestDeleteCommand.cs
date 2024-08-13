using OutOfOfficeDomain;
using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestDeleteCommand : CommandBase
    {
        private readonly LeaveRequestShowViewModel _viewModel;
        private readonly DeleteLeaveRequestService _deleteLeaveRequestService;

        public LeaveRequestDeleteCommand(LeaveRequestShowViewModel viewModel, DeleteLeaveRequestService deleteLeaveRequestService)
        {
            this._viewModel = viewModel;
            this._deleteLeaveRequestService = deleteLeaveRequestService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            var command = new DeleteLeaveRequest()
            {
                LeaveRequestId = this._viewModel.Id
            };
            this._deleteLeaveRequestService.Execute(command);
        }

        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Id))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
