using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;

namespace OutOfOfficeEF
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly OutOfOfficeDbContext context;

        public SqlEmployeeRepository(OutOfOfficeDbContext context)
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
            if (employee == null)
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
