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

        public void Save(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public Employee GetEmployeeById(Guid id)
        {
            Employee employee = this.context.Employees.First(x => x.Id == id);
            if(employee == null)
            {
                throw new Exception("Employee does not exist");
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }


    }
}
