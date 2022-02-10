using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01.Configs
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group").HasKey(g => g.GroupId);
            builder.Property(g => g.GroupId).HasColumnName("GroupId");
            builder.Property(g => g.Title).HasColumnName("Title").IsRequired();
        }
    }
}
