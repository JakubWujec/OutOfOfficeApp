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

//TODO dodac dropdown ze wszystkimi uzytkownikami do wyboru. DONE

namespace OutOfOfficeWPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        public ICommand LoginCommand { get; }
        private readonly NavigationService navigationService;
        private readonly IAuthenticator authenticator;
        private readonly EmployeeService employeeService;
        public LoginViewModel(NavigationService navigationService, IAuthenticator authenticator, EmployeeService employeeService)
        {
            this.authenticator = authenticator;
            this.navigationService = navigationService;
            this.employeeService = employeeService;
            this.LoginCommand = new LoginCommand(authenticator, navigationService);
        }

        public IEnumerable<Employee> Employees => employeeService.GetEmployees();

    }
}
