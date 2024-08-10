namespace OutOfOfficeDomain
{
    public class AuthenticationService
    {
        private EmployeeService employeeService;
        public AuthenticationService(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public Employee Login(Guid employeeId)
        {
            return this.employeeService.GetEmployeeById(employeeId);
        }
    }
}
