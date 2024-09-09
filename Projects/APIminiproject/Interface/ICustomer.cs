using APIminiproject.Models;

namespace APIminiproject.Interface
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task AddCustomer(Customer cus);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(int id , Customer cus);
    }
}
