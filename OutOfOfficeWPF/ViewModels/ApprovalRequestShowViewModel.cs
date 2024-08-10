
using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestShowViewModel: ViewModelBase
    {
        public ICommand CancelCommand { get; }
        private readonly ApprovalRequest _approvalRequest;
        public String FullName => _approvalRequest.LeaveRequest.Employee.FullName;
        public ApprovalRequestShowViewModel(INavigationService cancelNavigationService, ApprovalRequest approvalRequest)
        {
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
            this._approvalRequest = approvalRequest;
        }

    }
}
