
using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
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
        public ApprovalRequest SelectedRequest => _approvalRequest;
        public ICommand ApprovalRequestAcceptCommand { get; }
        
        public ApprovalRequestShowViewModel(
            INavigationService cancelNavigationService, 
            AcceptApprovalRequestService acceptApprovalRequestService,
            ApprovalRequest approvalRequest)
        {
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
            this._approvalRequest = approvalRequest;
            this.ApprovalRequestAcceptCommand = new ApprovalRequestAcceptCommand(this, acceptApprovalRequestService);
        }

    }
}
