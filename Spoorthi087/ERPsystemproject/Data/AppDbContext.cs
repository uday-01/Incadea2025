using Erpsystemfinal.Models;
using Microsoft.EntityFrameworkCore;


namespace Erpsystemfinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SalesOrders> SalesOrders { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrders>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.SalesOrders)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<PurchaseOrders>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}
