using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly OutOfOfficeContext context;

        public SqlEmployeeRepository(OutOfOfficeContext context)
        {
            this.context = context;
        }

        public void CreateEmployee(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }


    }
}
