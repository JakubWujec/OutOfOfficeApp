using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeListItemViewModel: ViewModelBase
    {
        private Employee _employee;
        public EmployeeListItemViewModel(Employee employee)
        {
            _employee = employee;
        }

        public Guid Id => _employee.Id;
        public String FullName => _employee.FullName;
        public bool IsActive => _employee.IsActive;
        public int OutOfOfficeBalance => _employee.OutOfOfficeBalance;
    }
}
