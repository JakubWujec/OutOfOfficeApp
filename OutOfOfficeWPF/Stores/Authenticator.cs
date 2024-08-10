using OutOfOfficeDomain;

namespace OutOfOfficeWPF.Stores
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthStore authStore;
        private readonly EmployeeService employeeService;
        public Authenticator(IAuthStore authStore, EmployeeService employeeService)
        {
            this.authStore = authStore;
            this.employeeService = employeeService;
        }
        public Employee CurrentEmployee => authStore.CurrentEmployee;
        public void Login(Guid id)
        {
            Employee employee = employeeService.GetEmployeeById(id);
            authStore.CurrentEmployee = employee;
        }
    }
}
