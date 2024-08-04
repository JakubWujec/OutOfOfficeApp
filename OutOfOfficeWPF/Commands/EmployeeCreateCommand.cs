using OutOfOfficeDomain;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OutOfOfficeWPF.Commands
{
    public class EmployeeCreateCommand : CommandBase
    {
        private readonly EmployeeCreateViewModel employeeCreateViewModel;
        private readonly EmployeeService employeeService;
        private readonly NavigationService<HomeViewModel> navigationService;
        public EmployeeCreateCommand(EmployeeCreateViewModel employeeCreateViewModel, EmployeeService employeeService, NavigationService<HomeViewModel> navigationService) { 
            this.navigationService = navigationService;
            this.employeeCreateViewModel = employeeCreateViewModel;
            this.employeeService = employeeService;
        }
        public override void Execute(object? parameter)
        {
            Employee newEmployee = new Employee()
            {
                FirstName = employeeCreateViewModel.FirstName,
                LastName = employeeCreateViewModel.LastName,
                IsActive = employeeCreateViewModel.IsActive,
                OutOfOfficeBalance = 26,
            };
            employeeService.CreateEmployee(newEmployee);
            this.navigationService.Navigate();
        }
    }
}
