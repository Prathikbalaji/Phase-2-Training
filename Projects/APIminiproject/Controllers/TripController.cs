using APIminiproject.Models;
using APIminiproject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIminiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<Trip>> Get()
        {
            return await _tripService.ViewTrips();
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet("{name}")]
        public async Task<IEnumerable<Trip>> Get(string name)
        {
            return await _tripService.ViewTripByID(name);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            return await _tripService.ViewTotalTripsCount();
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpPost]
        public async Task Post([FromBody] Trip trip)
        {
            await _tripService.AddTrip(trip);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("TripsCountForAllCustomers")]
        public async Task<Object> GetTripsCountForAllCustomers()
        {
            return await _tripService.GetTripsCountForAllCustomers();
        }
    }
}
