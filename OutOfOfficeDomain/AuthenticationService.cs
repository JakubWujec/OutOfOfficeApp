using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public class AuthenticationService
    {
        private EmployeeService employeeService;
        public AuthenticationService(EmployeeService employeeService) { 
            this.employeeService = employeeService;
        }
        public Employee Login(Guid employeeId)
        {
            return this.employeeService.GetEmployeeById(employeeId);
        }
    }
}
