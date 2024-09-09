using APIminiproject.Models;
using APIminiproject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIminiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _cus;

        public CustomerController(CustomerService cus)
        {
            _cus = cus;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _cus.GetCustomer();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task Post([FromBody] Customer cus)
        {
            await _cus.AddCustomer(cus);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _cus.DeleteCustomer(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] Customer cus)
        {
            await _cus.UpdateCustomer(id,cus);
        }

    }
}
