using Microsoft.EntityFrameworkCore;
using Assignment10.Models;
namespace Assignment10.Data
{
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        
    }
}
