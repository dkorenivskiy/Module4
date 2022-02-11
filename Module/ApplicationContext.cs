using Microsoft.EntityFrameworkCore;
using Module.Configs;
using Module.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //public ApplicationContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=EFPractice;User Id=dbuser;Password=qwerty;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfig());
            modelBuilder.ApplyConfiguration(new SongConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());

            modelBuilder.Entity<ArtistSong>().HasNoKey();
            modelBuilder.Ignore<ArtistSong>();

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Artists)
                .WithMany(a => a.Songs)
                .UsingEntity<ArtistSong>(
                j => j
                    .HasOne(sa => sa.Artist)
                    .WithMany(a => a.ArtistSongs)
                    .HasForeignKey(sa => sa.ArtistId),
                j => j
                    .HasOne(sa => sa.Song)
                    .WithMany(s => s.ArtistSongs)
                    .HasForeignKey(sa => sa.SongId));

            modelBuilder.Entity<ArtistSong>().HasData(new List<ArtistSong>()
            {
                new ArtistSong() {ArtistId = 1, SongId = 1},
                new ArtistSong() {ArtistId = 2, SongId = 3},
                new ArtistSong() {ArtistId = 3, SongId = 2},
                new ArtistSong() {ArtistId = 4, SongId = 4},
                new ArtistSong() {ArtistId = 5, SongId = 5}
            });
        }
    }
}
