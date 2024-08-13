using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeShowViewModel: ViewModelBase
    {
        public Employee Employee { get; }
        public EmployeeShowViewModel(Employee employee)
        {
            this.Employee = employee;
        }
    }
}
