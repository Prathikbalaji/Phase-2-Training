using APIminiproject.Models;
using APIminiproject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIminiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly VehicleService _ve;

        public VehicleController(VehicleService ve)
        {
            _ve = ve;
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _ve.GetVehicles();
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet("AvailableVehicles")]
        public async Task<IEnumerable<Vehicle>> AvailVehicles()
        {
            return await _ve.AvailableVehicles();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{status}")]
        public async Task<IEnumerable<Vehicle>> GetVehiclesByStatus(string status)
        {
            return await _ve.GetVehiclesByStatus(status);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task AddVehicles([FromBody] Vehicle veh)
        {
            await _ve.AddVehicle(veh);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle veh)
        {
            await _ve.AddMaintanence(veh);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task RemoveVehicle(int id)
        {
            await _ve.DeleteVehicle(id);
        }
    }
}
