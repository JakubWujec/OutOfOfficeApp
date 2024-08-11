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

namespace OutOfOfficeDomain.Tests
{
    public class EmployeeCreateViewModelTest
    {

        [Test]
        public void ExecuteSubmitCommand_WithValidEmployeeData_CreatesEmployee()
        {
            var dbContext = new InMemoryReservoomDbContextFactory().CreateDbContext();
            dbContext.Database.Migrate();

            var viewmodel = PrepareViewModel(dbContext);

            viewmodel.FirstName = "Test1";
            viewmodel.LastName = "Test2";

            viewmodel.SubmitCommand.Execute(viewmodel);

            Employee createdEmployee = dbContext.Employees.First();

            Assert.That(createdEmployee, Is.Not.Null);
        }

        private EmployeeCreateViewModel PrepareViewModel(OutOfOfficeDbContext dbContext)
        {
            var employeeRepository = new SqlEmployeeRepository(dbContext);
            var employeeService = new EmployeeService(employeeRepository);
            var navigationStore = new NavigationStore();
            var authStore = new AuthStore();
            var MakeHomeViewModel = () => new HomeViewModel(authStore);
            var mockNavigationService = new NavigationService(navigationStore, MakeHomeViewModel);
            var MakeNavigationBarViewModel = () => new NavigationBarViewModel(mockNavigationService, mockNavigationService, mockNavigationService, mockNavigationService, mockNavigationService, authStore);
            var homeNavigationService = new LayoutNavigationService<HomeViewModel>(navigationStore, MakeHomeViewModel, MakeNavigationBarViewModel);
            return new EmployeeCreateViewModel(employeeService, homeNavigationService); 
        }

    }
}
