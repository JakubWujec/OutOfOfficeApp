namespace OutOfOfficeDomain
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public void Save(Employee employee);

        public Employee GetEmployeeById(Guid id);

    }
}
