using APIminiproject.Interface;
using APIminiproject.Models;

namespace APIminiproject.Service
{
    public class VehicleService
    {
        private readonly IVehicle _ve;

        public VehicleService(IVehicle ve)
        {
            _ve = ve;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _ve.GetVehicles();
        }

        public async Task AddVehicle(Vehicle veh)
        {
            await _ve.AddVehicle(veh);
        }

        public async Task DeleteVehicle(int id)
        {
            await _ve.DeleteVehicle(id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByStatus(string status)
        {
            return await _ve.GetVehiclesByStatus(status);
        }

        public async Task AddMaintanence(Vehicle veh)
        {
            await _ve.AddMaintanence(veh);
        }

        public async Task<IEnumerable<Vehicle>> AvailableVehicles()
        {
            return await _ve.AvailableVehicles();
        }

    }
}
