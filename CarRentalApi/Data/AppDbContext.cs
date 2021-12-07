using CarRentalApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Book> books { get; set; }
    }
}
