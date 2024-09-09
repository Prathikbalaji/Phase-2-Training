using APIminiproject.Interface;
using APIminiproject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIminiproject.Repository
{
    public class TripRepository : ITrip
    {
        private readonly CustomerDBContext _context;

        public TripRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public async Task AddTrip(Trip trip)
        {
            if (trip == null)
            {
                throw new ArgumentNullException("Trip cannot be null.");
            }
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trip>> ViewTrips()
        {
            return await _context.Trips.Include(a => a.Customer).Include(b => b.Vehicle).ToListAsync();
        }

        public async Task<IEnumerable<Trip>> ViewTripByID(string CName)
        {

            if (string.IsNullOrEmpty(CName))
            {
                throw new ArgumentException("Customer name cannot be null or empty.");
            }

            Customer cus = _context.Customers.Where(c => c.Name == CName).FirstOrDefault() ?? new Customer();

            if (cus == null)
            {
                return Enumerable.Empty<Trip>();
            }

            var trips = await _context.Trips
                .Include(t => t.Customer)
                .Include(t => t.Vehicle)
                .Where(t => t.CustomerId == cus.CustomerId)
                .ToListAsync();

            return trips;
        }

        public async Task<int> ViewTotalTripsCount()
        {
            return await _context.Trips.CountAsync();
        }

        public async Task<Object> GetTripsCountForAllCustomers()
        {
            var customersTripCounts = await _context.Trips
                .GroupBy(t => t.CustomerId)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    CustomerName = _context.Customers
                        .Where(c => c.CustomerId == g.Key)
                        .Select(c => c.Name) 
                        .FirstOrDefault(),
                    TripsWent = g.Count()
                })
                .ToListAsync();

            return customersTripCounts;
        }

    }
}
