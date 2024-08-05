﻿using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeCreateViewModel: ViewModelBase
    {
        private readonly EmployeeService employeeService;
        private readonly INavigationService<HomeViewModel> navigationService;
        public EmployeeCreateViewModel(EmployeeService employeeService, INavigationService<HomeViewModel> homeNavigationService) {
            this.employeeService = employeeService;
            this.navigationService = homeNavigationService;
            this.SubmitCommand = new EmployeeCreateCommand(this, employeeService, homeNavigationService);
            this.CancelCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }

        public ICommand SubmitCommand { get;}
        public ICommand CancelCommand { get;}

        private string firstName = string.Empty;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value; OnPropertyChanged(nameof(FirstName));
            }
        }
        private string lastName = string.Empty;
        public string LastName
        {
            get { return lastName; }
            set {
                lastName = value; OnPropertyChanged(nameof(LastName));
            }
        }
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; OnPropertyChanged(nameof(IsActive)); }
        }


    }
}
