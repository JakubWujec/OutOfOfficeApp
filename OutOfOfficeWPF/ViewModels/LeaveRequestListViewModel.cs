﻿using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestListViewModel: ViewModelBase
    {
        private NavigationService navigationService;
        public ObservableCollection<LeaveRequestItemViewModel> LeaveRequests { get; }
        public ICommand NavigateToCommand { get; }
        public LeaveRequestListViewModel(IEnumerable<LeaveRequestItemViewModel> leaveRequests, NavigationService navigationService)
        {
            this.LeaveRequests = new ObservableCollection<LeaveRequestItemViewModel>(leaveRequests);
            this.navigationService = navigationService;
            NavigateToCommand = new NavigateCommand(navigationService);
        }
    }
}
