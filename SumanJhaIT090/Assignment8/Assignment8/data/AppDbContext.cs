using Assignment8.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment8.data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeTable> EmployeeTable { get; set; }
        public DbSet<DepartmentTable > DepartmentTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this code  is for primary key department table
            modelBuilder.Entity<DepartmentTable>()
                .HasKey(d=>d.deptid);

            // this code for primary key of employee table

            modelBuilder.Entity<EmployeeTable>()
                .HasKey(e=>e.empid);

            // code for foreign key constaunts

            modelBuilder.Entity<DepartmentTable>()
                .HasOne<EmployeeTable>()
                .WithMany()
                .HasForeignKey(e => e.deptid);

            ////some more 
            //modelBuilder.Entity<DepartmentTable>()
            //    .Property(d => d.departmentName)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //modelBuilder.Entity<EmployeeTable>()
            //    .Property(e=>e.empname)
            //    .IsRequired()
            //    .HasMaxLength(100);
        }

    }
}
