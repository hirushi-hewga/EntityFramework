using Airport_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Data_Access.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[]
            {
                new Account() { AccountId = 1, Username = "Colosquid", Password = "qwerty123" },
                new Account() { AccountId = 2, Username = "Sunada223", Password = "qwerty321" }
            });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight() { FlightId = 1, FlightDate = new DateTime(2024, 11, 20), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 2, FlightDate = new DateTime(2024, 11, 21), ArrivalCityId = 2, AircraftId = 2 }
            });
        }

        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City() { CityId = 1, CityName = "Kyiv", CountryId = 1 },
                new City() { CityId = 2, CityName = "Lviv", CountryId = 1 },
                new City() { CityId = 3, CityName = "Warsaw", CountryId = 2 },
                new City() { CityId = 4, CityName = "Berlin", CountryId = 3 }
            });
        }

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { CountryId = 1, CountryName = "Ukraine" },
                new Country() { CountryId = 2, CountryName = "Poland" },
                new Country() { CountryId = 3, CountryName = "Germany" }
            });
        }

        public static void SeedAircrafts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().HasData(new Aircraft[]
            {
                new Aircraft() { AircraftId = 1, AircraftModel = "Boeing 737", AircraftTypeId = 1 },
                new Aircraft() { AircraftId = 2, AircraftModel = "Boeing 777", AircraftTypeId = 2 }
            });
        }

        public static void SeedAircraftTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftType>().HasData(new AircraftType[]
            {
                new AircraftType() { AircraftTypeId = 1, TypeName = "Narrow-body" },
                new AircraftType() { AircraftTypeId = 2, TypeName = "Wide-body" }
            });
        }
    }
}
