using jwtapp.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
