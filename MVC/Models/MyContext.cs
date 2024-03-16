using Microsoft.EntityFrameworkCore;
namespace MVC.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Book>? Books { get; set; }
    }
}
