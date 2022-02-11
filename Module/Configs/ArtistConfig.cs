using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Configs
{
    class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.ArtistId);
            builder.Property(a => a.ArtistId).HasColumnName("ArtistId");
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.Property(a => a.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
            builder.Property(a => a.Phone).HasColumnName("Phone");
            builder.Property(a => a.Email).HasColumnName("Email");
            builder.Property(a => a.InstagramUrl).HasColumnName("InstagramUrl");

            builder.HasData(new List<Artist>()
            {
                new Artist() {ArtistId = 1, Name = "Red Hot Chili Peppers", DateOfBirth = new DateTime(1983)},
                new Artist() {ArtistId = 2, Name = "AC/DC", DateOfBirth = new DateTime(1973)},
                new Artist() {ArtistId = 3, Name = "Scorpions", DateOfBirth = new DateTime(1965)},
                new Artist() {ArtistId = 4, Name = "Depeche Mode", DateOfBirth = new DateTime(1980)},
                new Artist() {ArtistId = 5, Name = "Led Zeppelin", DateOfBirth = new DateTime(1968)}
            });
        }
    }
}
