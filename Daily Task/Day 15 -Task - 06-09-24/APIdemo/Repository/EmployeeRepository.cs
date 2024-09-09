using APIdemo.Interface;
using APIdemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIdemo.Repository
{
    public class EmployeeRepository : IEmployee
    {

        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(a => a.Organisation).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.empID == id) ?? new Employee();
        }

        public async Task AddEmployee(Employee emp)
        {
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
        }

    }
}
