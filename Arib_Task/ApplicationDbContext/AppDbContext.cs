using Arib_Task.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Arib_Task.ApplicationDbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // Employee → Manager
    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Manager)
        .WithMany(m => m.Employees)
        .HasForeignKey(e => e.ManagerId)
        .OnDelete(DeleteBehavior.Restrict);

            // Employee → Department
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Manager → Department
            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Department)
                .WithMany(d => d.Managers)
                .HasForeignKey(m => m.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmpTask → Manager
            modelBuilder.Entity<EmpTask>()
                .HasOne(t => t.Manager)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmpTask → Employee
            modelBuilder.Entity<EmpTask>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Employee> Employees{ get; set; } 
        public DbSet<Department> Departments{ get; set; } 
        public DbSet<EmpTask> EmpTasks{ get; set; } 
        public DbSet<Manager> Managers{ get; set; } 




    }
}
