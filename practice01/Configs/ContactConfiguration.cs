using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01.Configs
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact> 
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact").HasKey(c => c.ContactId);
            builder.Property(c => c.ContactId).HasColumnName("ContactId");
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");

            builder.HasOne(c => c.Group)
                .WithMany(g => g.Contacts)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
