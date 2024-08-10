namespace OutOfOfficeDomain
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Save(employee);
        }

        public Employee GetEmployeeById(Guid guid)
        {
            return _employeeRepository.GetEmployeeById(guid);
        }
    }
}
