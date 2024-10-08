﻿using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestCreateViewModel : ViewModelBase
    {
        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public LeaveRequestCreateViewModel(INavigationService leaveRequestListNavigationService, LeaveRequestService leaveRequestService, IAuthStore authStore)
        {
            this.CancelCommand = new NavigateCommand(leaveRequestListNavigationService);
            this.SubmitCommand = new LeaveRequestCreateCommand(this, leaveRequestListNavigationService, leaveRequestService, authStore);
        }
    }
}
