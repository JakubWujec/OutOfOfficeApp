using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ApprovalRequestItemViewModel> _approvalRequests;
        public ObservableCollection<ApprovalRequestItemViewModel> ApprovalRequests => _approvalRequests;

        private ApprovalRequestItemViewModel _selectedRequest = null;
        public ApprovalRequestItemViewModel SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        public ICommand ApprovalRequestAcceptCommand { get; }
        public ApprovalRequestListViewModel(ApprovalRequestService approvalRequestService, AcceptApprovalRequestService acceptApprovalRequestService)
        {
            _approvalRequests = new ObservableCollection<ApprovalRequestItemViewModel>();

            ApprovalRequestAcceptCommand = new ApprovalRequestAcceptCommand(this, acceptApprovalRequestService);

            UpdateList(approvalRequestService.GetApprovalRequests());
        }

        public void UpdateList(IEnumerable<ApprovalRequest> requests)
        {
            _approvalRequests.Clear();
            foreach (var request in requests)
            {
                _approvalRequests.Add(new ApprovalRequestItemViewModel(
                    request.LeaveRequest.StartDate,
                    request.LeaveRequest.EndDate,
                    request.Id,
                    status: request.Status.ToString()
                ));
            }
        }
    }
}
