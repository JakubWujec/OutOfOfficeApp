using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                OnPropertyChanged(nameof(CanOpenModal));
            }
        }

        public bool CanOpenModal => _selectedRequest != null;

        public ICommand NavigateCommand { get; }
        public ApprovalRequestListViewModel(
            ApprovalRequestService approvalRequestService,
            ParameterModalNavigationService<ApprovalRequest, ApprovalRequestShowViewModel> showViewModalNavigationService)
        {
            _approvalRequests = new ObservableCollection<ApprovalRequestItemViewModel>();
            NavigateCommand = new ParameterModalNavigateCommand<ApprovalRequest, ApprovalRequestShowViewModel>(showViewModalNavigationService);

            UpdateList(approvalRequestService.GetApprovalRequests());
        }

        public void UpdateList(IEnumerable<ApprovalRequest> requests)
        {
            _approvalRequests.Clear();
            foreach (var request in requests)
            {
                _approvalRequests.Add(new ApprovalRequestItemViewModel(
                   request
                ));
            }
        }
    }
}
