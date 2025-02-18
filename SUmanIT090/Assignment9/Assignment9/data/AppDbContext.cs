using Assignment9.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment9.data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        public DbSet<students> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<students>()
                .HasKey(s => s.studentid);

            
        }


    }
}
