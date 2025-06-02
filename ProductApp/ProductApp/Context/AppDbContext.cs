using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductApp.Models;

namespace ProductApp.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                        
        }
        public DbSet<Products> Products { get; set; } = null!;
    }
}
