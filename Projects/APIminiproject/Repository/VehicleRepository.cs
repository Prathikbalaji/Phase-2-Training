using APIminiproject.Interface;
using APIminiproject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIminiproject.Repository
{
    public class VehicleRepository : IVehicle
    {
        private readonly CustomerDBContext _context;

        public VehicleRepository(CustomerDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.Include(a => a.Trips).ThenInclude(b => b.Customer).ToListAsync();
        }
        public async Task AddVehicle(Vehicle ve)
        {
            if (ve == null)
            {
                throw new ArgumentNullException("Vehicle cannot be null.");
            }
            await _context.Vehicles.AddAsync(ve);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicle(int id)
        {

            Vehicle veh = await _context.Vehicles.FindAsync(id) ?? new Vehicle();
            if (veh == null)
            {
                throw new KeyNotFoundException($"Vehicle with ID {id} was not found.");
            }
            _context.Vehicles.Remove(veh);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByStatus(string status)
        {

            var vehicles = await _context.Vehicles
                .Where(t => t.MaintaneneceStatus == status)
                .ToListAsync();

            return vehicles;
        }

        public async Task AddMaintanence(Vehicle veh)
        {
            _context.Vehicles.Update(veh);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> AvailableVehicles()
        {
            return await _context.Vehicles.Where(a => a.IsAvailable == true).ToListAsync();
        }

    }
}
