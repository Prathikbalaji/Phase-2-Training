using Microsoft.EntityFrameworkCore;

namespace APIMTM.Models
{
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors {  get; set; }
        public DbSet<BookAuthor> BookAuthor {  get; set; }
        public BookDBContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
        }

    }
}
