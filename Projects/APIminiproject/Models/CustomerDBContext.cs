using Microsoft.EntityFrameworkCore;

namespace APIminiproject.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
        : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> users { get; set; }
    }
}
