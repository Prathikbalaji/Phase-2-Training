using Microsoft.EntityFrameworkCore;

namespace APIdemo.Models
{
    public class EmployeeDBContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Organisation> organisations { get; set; }

        public DbSet<User> users { get; set; }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> opt ) : base(opt) { }

    }
}
