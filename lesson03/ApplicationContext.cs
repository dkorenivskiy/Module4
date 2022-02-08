using lesson03.Configs;
using lesson03.DbItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    public class ApplicationContext : DbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Office> Offices { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Title> Titles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFPractice;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity<EmployeeProject>(
                    j => j
                        .HasOne(ep => ep.Employee)
                        .WithMany(e => e.EmployeeProjects)
                        .HasForeignKey(ep => ep.EmployeeId),
                    j => j
                        .HasOne(ep => ep.Project)
                        .WithMany(p => p.EmployeeProjects)
                        .HasForeignKey(pr => pr.ProjectId),
                    j =>
                    {
                        j.Property(ep => ep.Rate);
                        j.Property(ep => ep.StertedTime);
                        j.HasKey(t => new { t.EmployeeId, t.ProjectId });
                    }
                );
        }
    }
}
