﻿using _2024_09_20___HW__Migrations_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_20___HW__Migrations_
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
            //this.Database.EnsureCreated();
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
            optionsBuilder.UseSqlServer(@"workstation id=MusicDatabase_PPK14222_1.mssql.somee.com;
                                          packet size=4096;
                                          user id=Rovvffpol_SQLLogin_1;
                                          pwd=xkckezuwet;
                                          data source=MusicDatabase_PPK14222_1.mssql.somee.com;
                                          persist security info=False;
                                          initial catalog=MusicDatabase_PPK14222_1;
                                          TrustServerCertificate=True");
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
                    YearOfRelease = new DateOnly(2015,11,13), GenreId = 1, Rating = 7 },
                new Album { Id = 2, Name = "1989", ArtistId = 2,
                    YearOfRelease = new DateOnly(2014,10,27), GenreId = 1, Rating = 5 },
                new Album { Id = 3, Name = "Lemonade", ArtistId = 3,
                    YearOfRelease = new DateOnly(2016,4,23), GenreId = 2, Rating = 8 },
                new Album { Id = 4, Name = "+ (Divide)", ArtistId = 4,
                    YearOfRelease = new DateOnly(2017,3,3), GenreId = 3, Rating = 9 },
                new Album { Id = 5, Name = "FutureNostalgia", ArtistId = 5,
                    YearOfRelease = new DateOnly(2020,3,27), GenreId = 1, Rating = 6 },
                new Album { Id = 6, Name = "Rare", ArtistId = 6,
                    YearOfRelease = new DateOnly(2020,1,10), GenreId = 1, Rating = 8 }
            });
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
                new Track { Id = 1, Name = "What Do You Mean?", AlbumId = 1, Duration = new TimeOnly(0,3,25),
                    Text = "What Do You Mean?", Quantity = 42329, Rating = 6 },
                new Track { Id = 2, Name = "Blank Space", AlbumId = 2, Duration = new TimeOnly(0,3,51),
                    Text = "Blank Space", Quantity = 8976, Rating = 8 },
                new Track { Id = 3, Name = "Formation", AlbumId = 3, Duration = new TimeOnly(0,3,26),
                    Text = "Formation", Quantity = 19874, Rating = 5 },
                new Track { Id = 4, Name = "Castle on the Hill", AlbumId = 4, Duration = new TimeOnly(0,4,21),
                    Text = "Castle on the Hill", Quantity = 32912, Rating = 10 },
                new Track { Id = 5, Name = "Don`t Start Now", AlbumId = 5, Duration = new TimeOnly(0,3,3), 
                    Text = "Don`t Start Now", Quantity = 14565, Rating = 9 },
                new Track { Id = 6, Name = "Lose You to Love Me", AlbumId = 6, Duration = new TimeOnly(0,3,46),
                    Text = "Lose You to Love Me", Quantity = 45676, Rating = 4 }
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
                new Playlist { Id = 1, Name = "Pop Hits", CategoryId = 1, },
                new Playlist { Id = 2, Name = "R&B Selection", CategoryId = 2 },
                new Playlist { Id = 3, Name = "Mood Melodies", CategoryId = 3 },
                new Playlist { Id = 4, Name = "Emotional", CategoryId = 4 },
                new Playlist { Id = 5, Name = "Party", CategoryId = 5 }
            });
        }
    }
}
