using APIdemo.Interface;
using APIdemo.Models;

namespace APIdemo.Service
{
    public class EmployeeService
    {
        private readonly IEmployee emp;

        public EmployeeService(IEmployee emp)
        {
            this.emp = emp;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await emp.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await emp.GetEmployeeById(id);
        }

        public async Task AddEmployee(Employee empl)
        {
            await emp.AddEmployee(empl);
        }

    }
}
