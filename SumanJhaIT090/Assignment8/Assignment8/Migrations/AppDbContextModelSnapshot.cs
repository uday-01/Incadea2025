﻿// <auto-generated />
using Assignment8.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Assignment8.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Assignment8.Models.DepartmentTable", b =>
                {
                    b.Property<int>("deptid")
                        .HasColumnType("integer");

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("deptid");

                    b.ToTable("DepartmentTable");
                });

            modelBuilder.Entity("Assignment8.Models.EmployeeTable", b =>
                {
                    b.Property<int>("empid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("empid"));

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("departmentTabledeptid")
                        .HasColumnType("integer");

                    b.Property<int>("deptid")
                        .HasColumnType("integer");

                    b.Property<string>("empname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("salary")
                        .HasColumnType("integer");

                    b.HasKey("empid");

                    b.HasIndex("departmentTabledeptid");

                    b.ToTable("EmployeeTable");
                });

            modelBuilder.Entity("Assignment8.Models.DepartmentTable", b =>
                {
                    b.HasOne("Assignment8.Models.EmployeeTable", null)
                        .WithMany()
                        .HasForeignKey("deptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment8.Models.EmployeeTable", b =>
                {
                    b.HasOne("Assignment8.Models.DepartmentTable", "departmentTable")
                        .WithMany()
                        .HasForeignKey("departmentTabledeptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("departmentTable");
                });
#pragma warning restore 612, 618
        }
    }
}
