using APImanytomanyRepoPattern.Interface;
using APImanytomanyRepoPattern.Models;
using APImanytomanyRepoPattern.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APImanytomanyRepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentService _ser;

        public StudentController(StudentService ser)
        {
            _ser = ser;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _ser.getAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _ser.getStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task Post([FromBody] Student stud)
        {
            await _ser.AddStudent(stud);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Student stu)
        {
            await _ser.UpdateStudent(id, stu);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ser.DeleteStudent(id);
        }
    }
}
