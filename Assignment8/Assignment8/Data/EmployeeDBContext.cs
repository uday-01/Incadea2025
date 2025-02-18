using Microsoft.EntityFrameworkCore;
using Assignment8.Models;

namespace Assignment8.Data
{
    public class EmployeeDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EmployeeDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("SampleDBConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
