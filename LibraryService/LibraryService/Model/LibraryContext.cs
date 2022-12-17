using Microsoft.EntityFrameworkCore;
namespace LibraryService.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<tblBooks>  BookModel { get; set; }
    }
}
