using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeEF;
using OutOfOfficeWPF;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeDomain.Tests
{
    public class EmployeeCreateViewModelTest
    {

        [Test]
        public void ExecuteSubmitCommand_WithValidEmployeeData_CreatesEmployee()
        {
            var inMemoryContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            //var employeeRepository = new SqlEmployeeRepository(inMemoryContext);
            //var employeeService = new EmployeeService();
            //var viewModel = new EmployeeCreateViewModel()
        }
    }
}
