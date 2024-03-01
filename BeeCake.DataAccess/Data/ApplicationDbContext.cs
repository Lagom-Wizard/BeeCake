using BeeCake.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeCakeWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<CakeType> CakeType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
    }
}
