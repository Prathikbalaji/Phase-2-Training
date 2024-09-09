using APIminiproject.Interface;
using APIminiproject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIminiproject.Repository
{
    public class CustomerRepository : ICustomer
    {

        private readonly CustomerDBContext _context;

        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.Include(a=>a.Trips).ThenInclude(b=>b.Vehicle).ToListAsync();
        }

        public async Task AddCustomer(Customer c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("Customer cannot be null.");
            }
            await _context.Customers.AddAsync(c);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            Customer cus = await _context.Customers.FindAsync(id) ?? new Customer();
            if (cus == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} was not found.");
            }
            _context.Customers.Remove(cus);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCustomer(int id, Customer cus)
        {
            if (cus == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} was not found.");
            }
            _context.Customers.Update(cus);
            await _context.SaveChangesAsync();

        }

    }
}
