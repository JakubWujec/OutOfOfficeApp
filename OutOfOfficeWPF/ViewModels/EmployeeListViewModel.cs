using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeListViewModel: ViewModelBase
    {
        private readonly EmployeeService employeeService;
        private readonly ObservableCollection<EmployeeListItemViewModel> _employees;
        public ObservableCollection<EmployeeListItemViewModel> Employees => _employees;
        public EmployeeListViewModel(EmployeeService employeeService) { 
            this.employeeService = employeeService;
            this._employees = new ObservableCollection<EmployeeListItemViewModel>();

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
