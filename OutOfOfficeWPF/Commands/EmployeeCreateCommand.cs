using OutOfOfficeDomain;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.ViewModels;


namespace OutOfOfficeWPF.Commands
{
    public class EmployeeCreateCommand : CommandBase
    {
        private readonly EmployeeCreateViewModel employeeCreateViewModel;
        private readonly EmployeeService employeeService;
        private readonly INavigationService navigationService;
        public EmployeeCreateCommand(EmployeeCreateViewModel employeeCreateViewModel, EmployeeService employeeService, INavigationService navigationService)
        {
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
