using Microsoft.EntityFrameworkCore;

namespace MVCcodefirst.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Projects> Projects { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

    }
}
