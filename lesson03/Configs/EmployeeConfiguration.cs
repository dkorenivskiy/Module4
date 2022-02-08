using lesson03.DbItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.Configs
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.EmployeeId);
            builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(e => e.HiredDate).HasColumnName("HiredDate");
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");

            builder.HasMany(p => p.EmployeeProjects)
                .WithMany(e => e.Employees)
                .UsingEntity<Dictionary<string, object>>(
                "EmployeeProject",
                j => j
                .HasOne<EmployeeProject>()
                .WithMany()
                .HasForeignKey("ProjectId"),
                j => j
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey("EmployeeId"));
        }
    }
}
