using Microsoft.EntityFrameworkCore;
using sjhadelete.Models;

namespace sjhadelete.data
{
    public class AppDbContext :DbContext
    {
        public DbSet<StudentTable> StudentTable {  get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
