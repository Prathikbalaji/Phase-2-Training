using APIminiproject.Models;

namespace APIminiproject.Interface
{
    public interface ITrip
    {
        Task AddTrip(Trip trip);

        Task<IEnumerable<Trip>> ViewTrips();

        Task<IEnumerable<Trip>> ViewTripByID(string CName);

        Task<int> ViewTotalTripsCount();

        Task<Object> GetTripsCountForAllCustomers();

    }
}
