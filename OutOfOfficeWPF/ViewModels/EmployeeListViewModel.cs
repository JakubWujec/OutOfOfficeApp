using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeListViewModel: ViewModelBase
    {
        private readonly EmployeeService employeeService;
        private readonly ObservableCollection<EmployeeListItemViewModel> _employees;
        public ObservableCollection<EmployeeListItemViewModel> Employees => _employees;
        public ICommand NavigateCommand { get; }
        public EmployeeListViewModel(
            EmployeeService employeeService,
            INavigationService createEmployeeNavigationService
        ) { 
            this.employeeService = employeeService;
            this._employees = new ObservableCollection<EmployeeListItemViewModel>();
            this.NavigateCommand = new NavigateCommand(createEmployeeNavigationService);

            var employees = employeeService.GetEmployees();
            UpdateList(employees);
        }

        public void UpdateList(IEnumerable<Employee> employees)
        {
            _employees.Clear();
            foreach (var employee in employees)
            {
                _employees.Add(new EmployeeListItemViewModel(
                   employee
                ));
            }
        }
    }
}
