using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.BookStoreContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookGallery> BookGalleries { get; set; }
    }
}
