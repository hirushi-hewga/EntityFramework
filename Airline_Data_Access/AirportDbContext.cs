﻿using Airport_Data_Access.Entities;
using Airport_Data_Access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Data_Access
{
    public class AirportDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=AirportDbContext_14288.mssql.somee.com;
                                            packet size=4096;
                                            user id=Huhdfshdsfo_SQLLogin_1;
                                            pwd=tfnup3tjmy;
                                            data source=AirportDbContext_14288.mssql.somee.com;
                                            persist security info=False;
                                            initial catalog=AirportDbContext_14288;
                                            TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Validation

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
        }
    }
}