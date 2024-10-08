﻿using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

//TODO sort by column click


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<LeaveRequestItemViewModel> _leaveRequests;
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests => _leaveRequests;
        public ICommand NavigateCommand { get; }
        public ICommand OpenSelectedCommand {get;}
 
        private LeaveRequestItemViewModel _selectedLeaveRequest = null;
        public LeaveRequestItemViewModel SelectedLeaveRequest
        {
            get => _selectedLeaveRequest;
            set
            {
                _selectedLeaveRequest = value;
                OnPropertyChanged(nameof(SelectedLeaveRequest));
            }
        }
        public LeaveRequestListViewModel(LeaveRequestService leaveRequestService, INavigationService createLeaveRequestNavigationService, 
            ParameterModalNavigationService<LeaveRequest, LeaveRequestShowViewModel> showViewModalNavigationService)
        {
            _leaveRequests = new ObservableCollection<LeaveRequestItemViewModel>();
            NavigateCommand = new NavigateCommand(createLeaveRequestNavigationService);
            OpenSelectedCommand = new ParameterModalNavigateCommand<LeaveRequest, LeaveRequestShowViewModel>(showViewModalNavigationService);

            UpdateLeaveRequests(leaveRequestService.GetAll());
        }

        public void UpdateLeaveRequests(IEnumerable<LeaveRequest> leaveRequests)
        {
            LeaveRequests.Clear();
            foreach (var item in leaveRequests)
            {
                LeaveRequests.Add(new LeaveRequestItemViewModel(
                   item
                ));
            }
        }
    }
}
