using Microsoft.EntityFrameworkCore;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<PurchaseOrder> purchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().
                HasKey(e=>e.UserId);
            modelBuilder.Entity<Users>().
                Property(e => e.UserId)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Products>().
                HasKey(e=>e.ProductId);
            modelBuilder.Entity<Products>().
                Property(e => e.ProductId)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Customers>().
                HasKey(e=>e.CustomerId);
             modelBuilder.Entity<Customers>().
                Property(e => e.CustomerId).
                ValueGeneratedOnAdd();


            modelBuilder.Entity<Suppliers>().
                HasKey(e=>e.SupplierId);
            modelBuilder.Entity<Suppliers>().
                Property(e=>e.SupplierId).
                ValueGeneratedOnAdd();


            modelBuilder.Entity<SalesOrder>().
                HasKey(e => e.SalesOrderId);
            modelBuilder.Entity<SalesOrder>().
                Property(e=>e.SalesOrderId).
                ValueGeneratedOnAdd();
            modelBuilder.Entity<SalesOrder>()
                .HasOne(c=>c.Customers)
                .WithMany(c=>c.SalesOrders)
                .HasForeignKey(e=>e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SalesOrder>()
                .HasOne(c => c.Users)
                .WithMany(c => c.SalesOrders) 
                .HasForeignKey(e => e.UserId) 
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SalesOrder>()
                .HasOne(c=>c.Products)
                .WithMany(p=>p.SalesOrders)
                .HasForeignKey(c=>c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PurchaseOrder>().
                HasKey(e => e.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrder>().
                Property(e => e.PurchaseOrderId).
                ValueGeneratedOnAdd();
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(c => c.Suppliers)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(c => c.Users)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(c => c.Products)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
