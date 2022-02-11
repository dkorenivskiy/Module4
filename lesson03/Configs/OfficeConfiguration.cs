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
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.Location).HasColumnName("Location");

            builder.HasOne(d => d.Employee)
                .WithOne(p => p.Office)
                .HasForeignKey<Employee>(b => b.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
