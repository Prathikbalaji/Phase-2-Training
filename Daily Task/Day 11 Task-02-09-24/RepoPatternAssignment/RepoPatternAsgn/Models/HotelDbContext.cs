using Microsoft.EntityFrameworkCore;

namespace RepoPatternAsgn.Models
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HotelDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=MVCPrathikHotel;integrated security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel() { HotelId = 1 ,HotelName="Jahseh"});
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomID = 1, RoomNo = 01, RoomType = "Ac", Price = 1500 });
            modelBuilder.Entity<Hotel>()
                .HasMany(o => o.Rooms)
                .WithOne(c => c.hotel)
                .HasForeignKey(c => c.HotelID);
            modelBuilder.Entity<Room>()
                .Property(o => o.Price)
                .HasColumnType("decimal(10,2)");
        }


    }
}
