using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ApprovalRequestItemViewModel> _approvalRequests;
        private readonly ParameterModalNavigationService<ApprovalRequest, ApprovalRequestShowViewModel> _showViewModalNavigation;
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
        public ICommand NavigateCommand { get; }
        public ApprovalRequestListViewModel(
            ApprovalRequestService approvalRequestService, 
            ParameterModalNavigationService<ApprovalRequest, ApprovalRequestShowViewModel> showViewModalNavigationService)
        {
            _approvalRequests = new ObservableCollection<ApprovalRequestItemViewModel>();
            _showViewModalNavigation = showViewModalNavigationService;

            this.NavigateCommand = new ParameterModalNavigateCommand<ApprovalRequest, ApprovalRequestShowViewModel>(_showViewModalNavigation);
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
