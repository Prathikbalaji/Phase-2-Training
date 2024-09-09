using APIminiproject.Interface;
using APIminiproject.Models;

namespace APIminiproject.Service
{
    public class TripService
    {
        private readonly ITrip _tr;

        public TripService(ITrip tr)
        {
            _tr = tr;
        }
        public async Task AddTrip(Trip trip)
        {
            await _tr.AddTrip(trip);
        }

        public async Task<IEnumerable<Trip>> ViewTrips()
        {
            return await _tr.ViewTrips();
        }

        public async Task<IEnumerable<Trip>> ViewTripByID(string CName)
        {
            return await _tr.ViewTripByID(CName);
        }

        public async Task<int> ViewTotalTripsCount()
        {
            return await _tr.ViewTotalTripsCount();
        }

        public async Task<Object> GetTripsCountForAllCustomers()
        {
            return await _tr.GetTripsCountForAllCustomers();
        }

    }
}
