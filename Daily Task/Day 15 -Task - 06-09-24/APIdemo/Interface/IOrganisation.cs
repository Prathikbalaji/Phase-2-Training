using APIdemo.Models;

namespace APIdemo.Interface
{
    public interface IOrganisation
    {
        Task<IEnumerable<Organisation>> GetAllOrganisations();

        Task<Organisation> GetOrganisationById(int id);

        Task AddOrganisation(Organisation org);

    }
}
