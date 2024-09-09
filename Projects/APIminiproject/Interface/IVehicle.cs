using APIminiproject.Models;

namespace APIminiproject.Interface
{
    public interface IVehicle
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<IEnumerable<Vehicle>> AvailableVehicles();

        Task<IEnumerable<Vehicle>> GetVehiclesByStatus(string status);

        Task AddMaintanence(Vehicle veh);

        Task AddVehicle(Vehicle ve);

        Task DeleteVehicle(int id);
    }
}
