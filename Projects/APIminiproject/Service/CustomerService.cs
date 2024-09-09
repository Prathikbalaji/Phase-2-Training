using APIminiproject.Interface;
using APIminiproject.Models;

namespace APIminiproject.Service
{
    public class CustomerService 
    {
        private readonly ICustomer _cus;

        public CustomerService(ICustomer cus)
        {
            _cus = cus;
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _cus.GetCustomers();
        }

        public async Task AddCustomer(Customer customer)
        {
            await _cus.AddCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _cus.DeleteCustomer(id);
        }

        public async Task UpdateCustomer(int id, Customer cus)
        {
            await _cus.UpdateCustomer(id,cus);
        }

    }
}
