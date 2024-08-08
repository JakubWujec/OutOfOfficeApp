using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public void Save(Employee employee);

        public Employee GetEmployeeById(Guid id);

    }
}
