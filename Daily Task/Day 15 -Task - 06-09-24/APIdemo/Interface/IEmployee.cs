using APIdemo.Models;

namespace APIdemo.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);

        Task AddEmployee(Employee emp);
    }
}
