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
                new Flight() { FlightId = 2, FlightDate = new DateTime(2024, 11, 21), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 3, FlightDate = new DateTime(2024, 11, 22), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 4, FlightDate = new DateTime(2024, 11, 23), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 5, FlightDate = new DateTime(2024, 11, 24), ArrivalCityId = 3, AircraftId = 1 },
                new Flight() { FlightId = 6, FlightDate = new DateTime(2024, 11, 25), ArrivalCityId = 4, AircraftId = 2 },
                new Flight() { FlightId = 7, FlightDate = new DateTime(2024, 11, 26), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 8, FlightDate = new DateTime(2024, 11, 27), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 9, FlightDate = new DateTime(2024, 11, 28), ArrivalCityId = 3, AircraftId = 1 },
                new Flight() { FlightId = 10, FlightDate = new DateTime(2024, 11, 29), ArrivalCityId = 4, AircraftId = 2 },
                new Flight() { FlightId = 11, FlightDate = new DateTime(2024, 11, 30), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 12, FlightDate = new DateTime(2024, 12, 01), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 13, FlightDate = new DateTime(2024, 12, 02), ArrivalCityId = 3, AircraftId = 1 },
                new Flight() { FlightId = 14, FlightDate = new DateTime(2024, 12, 03), ArrivalCityId = 4, AircraftId = 2 },
                new Flight() { FlightId = 15, FlightDate = new DateTime(2024, 12, 04), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 16, FlightDate = new DateTime(2024, 12, 05), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 17, FlightDate = new DateTime(2024, 12, 06), ArrivalCityId = 3, AircraftId = 1 },
                new Flight() { FlightId = 18, FlightDate = new DateTime(2024, 12, 07), ArrivalCityId = 4, AircraftId = 2 },
                new Flight() { FlightId = 19, FlightDate = new DateTime(2024, 12, 08), ArrivalCityId = 1, AircraftId = 1 },
                new Flight() { FlightId = 20, FlightDate = new DateTime(2024, 12, 09), ArrivalCityId = 2, AircraftId = 2 },
                new Flight() { FlightId = 21, FlightDate = new DateTime(2024, 12, 10), ArrivalCityId = 3, AircraftId = 1 },
                new Flight() { FlightId = 22, FlightDate = new DateTime(2024, 12, 11), ArrivalCityId = 4, AircraftId = 2 }
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
