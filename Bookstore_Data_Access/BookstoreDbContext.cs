﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_Data_Access
{
    public partial class BookstoreDbContext : DbContext
    {
        /*public DbSet<Account> Accounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Flight> Flights { get; set; }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=Bookstore_Exam.mssql.somee.com;
                                            packet size=4096;
                                            user id=EFiopjIOJIEDV_SQLLogin_1;
                                            pwd=vfjplt2j4f;
                                            data source=Bookstore_Exam.mssql.somee.com;
                                            persist security info=False;initial catalog=Bookstore_Exam;
                                            TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Validation
            /*
            #region Account

            modelBuilder.Entity<Account>()
                .Property(a => a.Username)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(a => a.Password)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region City

            modelBuilder.Entity<City>()
                .Property(c => c.CityName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(c => c.Flights)
                .WithOne(f => f.ArrivalCity)
                .HasForeignKey(f => f.ArrivalCityId);

            #endregion

            #region Country

            modelBuilder.Entity<Country>()
                .Property(c => c.CountryName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);

            #endregion

            #region Aircraft

            modelBuilder.Entity<Aircraft>()
                .Property(a => a.AircraftModel)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Aircraft>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Aircraft)
                .HasForeignKey(f => f.AircraftId);

            #endregion

            #region AircraftType

            modelBuilder.Entity<AircraftType>()
                .Property(a => a.TypeName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<AircraftType>()
                .HasMany(a => a.Aircrafts)
                .WithOne(a => a.AircraftType)
                .HasForeignKey(a => a.AircraftTypeId);

            #endregion


            // Initialization

            modelBuilder.SeedAccounts();
            modelBuilder.SeedAircraftTypes();
            modelBuilder.SeedCountries();
            modelBuilder.SeedAircrafts();
            modelBuilder.SeedCities();
            modelBuilder.SeedFlights();
            */
        }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime YearOfRelease { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public Book ContinuationBook { get; set; }
        public int ContinuationBookId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Publisher
    {
        public int AuthorId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
