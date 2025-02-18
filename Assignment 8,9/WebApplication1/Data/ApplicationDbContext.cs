using WebApplication1.Models;

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data

{

    public class ApplicationDbContext : DbContext

    {

        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)

        {

            Configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)

        {

            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

        }

        public DbSet<student> students { get; set; }

    }

}

