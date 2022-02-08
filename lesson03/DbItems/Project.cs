using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartedTime { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }

    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Budget).HasColumnName("Budget");
            builder.Property(p => p.StartedTime).HasColumnName("StartedTime");

            builder.HasMany(p => p.EmployeeProjects)
        }
    }
}
