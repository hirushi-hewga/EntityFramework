using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
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
                new Country { Id = 1, Name = "Canada" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "United Kingdom" }
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist { Id = 1, Name = "Justin", Surname = "Bieber", CountryId = 1 },
                new Artist { Id = 2, Name = "Taylor", Surname = "Swift", CountryId = 2 },
                new Artist { Id = 3, Name = "Beyonce", Surname = "Knowles", CountryId = 2 },
                new Artist { Id = 4, Name = "Ed", Surname = "Sheeran", CountryId = 3 },
                new Artist { Id = 5, Name = "Dua", Surname = "Lipa", CountryId = 3 },
                new Artist { Id = 6, Name = "Selena", Surname = "Gomez", CountryId = 2 },
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre { Id = 1, Name = "Pop"},
                new Genre { Id = 2, Name = "R&B"},
                new Genre { Id = 3, Name = "Pop/Folk"}
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album { Id = 1, Name = "Purpose", ArtistId = 1, 
                    YearOfRelease = new DateOnly(2015,11,13), GenreId = 1 },
                new Album { Id = 2, Name = "1989", ArtistId = 2, 
                    YearOfRelease = new DateOnly(2014,10,27), GenreId = 1 },
                new Album { Id = 3, Name = "Lemonade", ArtistId = 3, 
                    YearOfRelease = new DateOnly(2016,4,23), GenreId = 2 },
                new Album { Id = 4, Name = "+ (Divide)", ArtistId = 4, 
                    YearOfRelease = new DateOnly(2017,3,3), GenreId = 3 },
                new Album { Id = 5, Name = "FutureNostalgia", ArtistId = 5, 
                    YearOfRelease = new DateOnly(2020,3,27), GenreId = 1 },
                new Album { Id = 6, Name = "Rare", ArtistId = 6, 
                    YearOfRelease = new DateOnly(2020,1,10), GenreId = 1 }
            });
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
                new Track { Id = 1, Name = "What Do You Mean?", AlbumId = 1, Duration = new TimeOnly(0,3,25) },
                new Track { Id = 2, Name = "Blank Space", AlbumId = 2, Duration = new TimeOnly(0,3,51) },
                new Track { Id = 3, Name = "Formation", AlbumId = 3, Duration = new TimeOnly(0,3,26) },
                new Track { Id = 4, Name = "Castle on the Hill", AlbumId = 4, Duration = new TimeOnly(0,4,21) },
                new Track { Id = 5, Name = "Don`t Start Now", AlbumId = 5, Duration = new TimeOnly(0,3,3) },
                new Track { Id = 6, Name = "Lose You to Love Me", AlbumId = 6, Duration = new TimeOnly(0,3,46) },
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Pop" },
                new Category { Id = 2, Name = "R&B" },
                new Category { Id = 3, Name = "Mood Music" },
                new Category { Id = 4, Name = "Emotional Songs" },
                new Category { Id = 5, Name = "Party" },
            });
            modelBuilder.Entity<Playlist>().HasData(new Playlist[]
            {
                new Playlist { Id = 1, Name = "Pop Hits", CategoryId = 1 },
                new Playlist { Id = 2, Name = "R&B Selection", CategoryId = 2 },
                new Playlist { Id = 3, Name = "Mood Melodies", CategoryId = 3 },
                new Playlist { Id = 4, Name = "Emotional", CategoryId = 4 },
                new Playlist { Id = 5, Name = "Party", CategoryId = 5 }
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
        public DateOnly YearOfRelease { get; set; }
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
        public TimeOnly Duration { get; set; }
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

    public class PlaylistTrack
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
