using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;


namespace OutOfOfficeWPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
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
