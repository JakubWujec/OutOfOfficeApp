using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ApprovalRequestListViewModel(ApprovalRequestService approvalRequestService)
        {
            _approvalRequests = new ObservableCollection<ApprovalRequestItemViewModel>();
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
                    request.Id
                ));
            }
        }
    }
}
