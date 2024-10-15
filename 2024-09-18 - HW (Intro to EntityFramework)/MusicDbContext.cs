using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_18___HW__Intro_to_EntityFramework_
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                         Initial Catalog=MusicDb_PP1402
                                          Integrated Security=True;
                                          Connect Timeout=2;
                                          Encrypt=True;
                                          Trust Server Certificate=True;
                                          Application Intent=ReadWrite;
                                          Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
                new Track { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = ""}
            });
            modelBuilder.Entity<Playlist>().HasData(new Playlist[]
            {
                new Playlist { Id = 1, Name = ""}
            });
        }
    }

    public class Country
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }

    public class Artist
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(100)]
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Album> Albums { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }

    public class Track
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public int Duration { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }

    public class Playlist
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
