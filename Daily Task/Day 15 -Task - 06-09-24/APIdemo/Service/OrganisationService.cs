using APIdemo.Interface;
using APIdemo.Models;

namespace APIdemo.Service
{
    public class OrganisationService
    {
        private readonly IOrganisation org;

        public OrganisationService(IOrganisation org)
        {
            this.org = org;
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            return await org.GetAllOrganisations();
        }

        public async Task<Organisation> GetOrganisationById(int id)
        {
            return await org.GetOrganisationById(id);
        }

        public async Task AddOrganisation(Organisation orgn)
        {
            await org.AddOrganisation(orgn);
        }

    }
}
