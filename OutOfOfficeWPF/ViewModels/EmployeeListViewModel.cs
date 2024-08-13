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

        private EmployeeListItemViewModel _selected = null;
        public EmployeeListItemViewModel Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
                OnPropertyChanged(nameof(CanOpenSelected));
            }
        }

        public bool CanOpenSelected => _selected != null;
        public ICommand NavigateCommand { get; }
        public ICommand OpenSelectedCommand {  get; }
        public EmployeeListViewModel(
            EmployeeService employeeService,
            INavigationService createEmployeeNavigationService,
            ParameterModalNavigationService<Employee, EmployeeShowViewModel> showViewModalNavigationService
        ) { 
            this.employeeService = employeeService;
            this._employees = new ObservableCollection<EmployeeListItemViewModel>();
            this.NavigateCommand = new NavigateCommand(createEmployeeNavigationService);
            this.OpenSelectedCommand = new ParameterModalNavigateCommand<Employee, EmployeeShowViewModel>(showViewModalNavigationService);

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
