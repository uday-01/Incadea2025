using Microsoft.EntityFrameworkCore;
using Practice_1.Models;

namespace Practice_1.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options):base(options) { }

        public DbSet<Hospital> hospitals { get; set; }
    }
}
