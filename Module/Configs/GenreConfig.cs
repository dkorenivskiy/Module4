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
    class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.GenreId);
            builder.Property(g => g.GenreId).HasColumnName("GenreId").IsRequired();
            builder.Property(g => g.Title).HasColumnName("Title").IsRequired();

            builder.HasData(new List<Genre>()
            {
                new Genre() {GenreId = 1, Title = "Rock"},
                new Genre() {GenreId = 2, Title = "Punk-Rock"},
                new Genre() {GenreId = 3, Title = "Hard Rock"},
                new Genre() {GenreId = 4, Title = "Industrial"},
                new Genre() {GenreId = 5, Title = "Funk-Rock"}
            });
        }
    }
}
