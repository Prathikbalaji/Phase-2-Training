using APIdemo.Interface;
using APIdemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIdemo.Repository
{
    public class OrganisationRepository : IOrganisation
    {
        private readonly EmployeeDBContext _context;

        public OrganisationRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Organisation>> GetAllOrganisations()
        {
            return await _context.organisations.Include(a => a.Employee).ToListAsync();
        }

        public async Task<Organisation> GetOrganisationById(int id)
        {
            return await _context.organisations.FirstOrDefaultAsync(a => a.OrgId == id) ?? new Organisation();
        }

        public async Task AddOrganisation(Organisation org)
        {
            await _context.organisations.AddAsync(org);
            await _context.SaveChangesAsync();
        }

    }
}
