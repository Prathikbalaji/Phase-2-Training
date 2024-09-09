using APIdemo.Models;
using APIdemo.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        private readonly OrganisationService org;

        public OrgController(OrganisationService org)
        {
            this.org = org;
        }

        // GET: api/<OrgController>
        [HttpGet]
        public async Task<IEnumerable<Organisation>> Get()
        {
            return await org.GetOrganisations();
        }

        // GET api/<OrgController>/5
        [HttpGet("{id}")]
        public async Task<Organisation> Get(int id)
        {
            return await org.GetOrganisationById(id);
        }

        // POST api/<OrgController>
        [HttpPost]
        public async Task Post([FromBody] Organisation orgn)
        {
            await org.AddOrganisation(orgn);
        }

        // PUT api/<OrgController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrgController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
