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
    class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(s => s.SongId);
            builder.Property(s => s.SongId).HasColumnName("SongId").IsRequired();
            builder.Property(s => s.Title).HasColumnName("Title").IsRequired();
            builder.Property(s => s.Duration).HasColumnName("Duration").IsRequired();
            builder.Property(s => s.ReleasedDate).HasColumnName("ReleasedDate").IsRequired();

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Song>()
            {
                new Song() {SongId = 1, Title = "Scar Tissue", Duration = "3.12", ReleasedDate = new DateTime(1999), GenreId = 2},
                new Song() {SongId = 2, Title = "Rock You Like a Hurricane", Duration = "3.32", ReleasedDate = new DateTime(1995), GenreId = 1},
                new Song() {SongId = 3, Title = "Thunderstruck", Duration = "4.53", ReleasedDate = new DateTime(1990), GenreId = 3},
                new Song() {SongId = 4, Title = "Personal Jesus", Duration = "3.45", ReleasedDate = new DateTime(1998), GenreId = 4},
                new Song() {SongId = 5, Title = "Immigration Song", Duration = "3.54", ReleasedDate = new DateTime(1996), GenreId = 5}
            });
        }
    }
}
