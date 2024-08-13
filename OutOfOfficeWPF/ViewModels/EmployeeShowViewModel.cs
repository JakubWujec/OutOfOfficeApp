using OutOfOfficeDomain;
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
    public class EmployeeShowViewModel: ViewModelBase
    {
        public Employee Employee { get; }
        public ICommand CancelCommand { get; set; }
        public EmployeeShowViewModel(
            INavigationService cancelNavigationService, 
            Employee employee
        )
        {
            this.Employee = employee;
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
        }
    }
}
