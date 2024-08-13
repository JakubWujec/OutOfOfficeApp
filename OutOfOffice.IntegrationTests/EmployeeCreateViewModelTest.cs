using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OutOfOfficeEF;
using OutOfOfficeWPF;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using OutOfOfficeDomain;

namespace OutOfOffice.IntegrationTests
{
    public class EmployeeCreateViewModelTest
    {

        [Test]
        public void ExecuteSubmitCommand_WithValidEmployeeData_CreatesEmployee()
        {
            var dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            dbContext.Database.Migrate();

            var viewmodel = PrepareViewModel(dbContext);

            viewmodel.FirstName = "Test1111";
            viewmodel.LastName = "Test2222";

            viewmodel.SubmitCommand.Execute(viewmodel);

            Employee createdEmployee = dbContext.Employees.Where(e => e.FirstName == viewmodel.FirstName).First();

            Assert.That(createdEmployee, Is.Not.Null);
        }

        [Test]
        public void ExecuteSubmitCommand_WithValidEmployeeDataWithoutPosition_CreatesMemberEmployee()
        {
            var dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            dbContext.Database.Migrate();

            var viewmodel = PrepareViewModel(dbContext);

            viewmodel.FirstName = "Test1";
            viewmodel.LastName = "Test2";

            viewmodel.SubmitCommand.Execute(viewmodel);

            Employee createdEmployee = dbContext.Employees
                .Where(e => e.FirstName == viewmodel.FirstName)
                .First();

            Assert.That(createdEmployee.Position, Is.EqualTo(Position.Member));
        }

        private EmployeeCreateViewModel PrepareViewModel(OutOfOfficeDbContext dbContext)
        {
            var employeeRepository = new SqlEmployeeRepository(dbContext);
            var employeeService = new EmployeeService(employeeRepository);
            var navigationStore = new NavigationStore();
            var authStore = new AuthStore();
            var makeHomeViewModel = () => new HomeViewModel(authStore);
            var mockNavigationService = new NavigationService(navigationStore, makeHomeViewModel);
            var homeNavigationService = new NavigationService(navigationStore, makeHomeViewModel);
            return new EmployeeCreateViewModel(employeeService, homeNavigationService); 
        }

    }
}
