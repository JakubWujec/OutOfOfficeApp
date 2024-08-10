using OutOfOfficeDomain;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Commands
{
    public class LeaveRequestCreateCommand : CommandBase
    {
        private readonly LeaveRequestCreateViewModel _viewModel;
        private readonly INavigationService _leaveRequestListNavigationService;
        private readonly LeaveRequestService _leaveRequestService;
        private readonly IAuthStore _authStore;
        public LeaveRequestCreateCommand(LeaveRequestCreateViewModel viewModel, INavigationService navigationService, LeaveRequestService leaveRequestService, IAuthStore authStore)
        {
            this._viewModel = viewModel;
            this._leaveRequestListNavigationService = navigationService;
            this._leaveRequestService = leaveRequestService;
            this._authStore = authStore;
        }
        public override void Execute(object? parameter)
        {
            if (!_authStore.IsLoggedIn)
            {
                throw new Exception("Not authorized");
            }

            LeaveRequest leaveRequest = new LeaveRequest()
            {
                StartDate = DateOnly.FromDateTime(_viewModel.StartDate),
                EndDate = DateOnly.FromDateTime(_viewModel.EndDate),
                Comment = "no reason",
                EmployeeId = _authStore.CurrentEmployee.Id
            };
            _leaveRequestService.CreateLeaveRequest(leaveRequest);
            _leaveRequestListNavigationService.Navigate();
        }
    }
}
