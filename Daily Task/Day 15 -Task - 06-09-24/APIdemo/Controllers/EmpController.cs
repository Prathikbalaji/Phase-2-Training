using APIdemo.Models;
using APIdemo.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmployeeService emp;

        public EmpController(EmployeeService emp)
        {
            this.emp = emp;
        }

        // GET: api/<EmpController>
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await emp.GetEmployees();
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await emp.GetEmployeeById(id);
        }

        // POST api/<EmpController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task Post([FromBody] Employee empl)
        {
            await emp.AddEmployee(empl);
        }

        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
