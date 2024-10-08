﻿using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }
        private readonly INavigationService homeNavigationService;
        private readonly IAuthenticator authenticator;
        private readonly EmployeeService employeeService;
        public LoginViewModel(INavigationService homeNavigationService, IAuthenticator authenticator, EmployeeService employeeService)
        {
            this.authenticator = authenticator;
            this.homeNavigationService = homeNavigationService;
            this.employeeService = employeeService;
            this.LoginCommand = new LoginCommand(this, authenticator, homeNavigationService);
            this._selectedEmployee = authenticator.CurrentEmployee;
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                //  OnPropertyChanged();
            }
        }


        public IEnumerable<Employee> Employees => employeeService.GetEmployees();

    }
}
