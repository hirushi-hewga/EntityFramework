using _2024_09_25___Lesson__Loading_Data_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_25___Lesson__Loading_Data_.Helpers
{
    public static class DbInitializer
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country { Id = 1, Name = "Ukraine" },
                new Country { Id = 2, Name = "Poland" },
                new Country { Id = 3, Name = "Germany" }
            });
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City { Id = 1, Name = "Kyiv", CountryId = 1 },
                new City { Id = 2, Name = "Lviv", CountryId = 1 },
                new City { Id = 3, Name = "Warsaw", CountryId = 2 }
            });
        }
        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop[]
            {
                new Shop { Id = 1, Name = "Fashion Boutique", Address = "St. Lesi Ukrainka, 1",
                           CityId = 1, ParkingArea = 5 },
                new Shop { Id = 2, Name = "Electronics", Address = "Ave. Victories, 2",
                           CityId = 1, ParkingArea = 10 },
                new Shop { Id = 3, Name = "Supermarket", Address = "St. Hrushevsky, 3",
                           CityId = 2, ParkingArea = 15 }
            });
        }
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position { Id = 1, Name = "Manager" },
                new Position { Id = 2, Name = "Seller" },
                new Position { Id = 3, Name = "Cashier" }
            });
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker { Id = 1, Name = "Ivan", Surname = "Petrenko", Salary = 2000,
                    Email = "ivan@gmail.com", PhoneNumber = "+380123456789", PositionId = 1, ShopId = 1 },
                new Worker { Id = 2, Name = "Olena", Surname = "Sydorenko", Salary = 1500,
                    Email = "olena@gmail.com", PhoneNumber = "+380987654321", PositionId = 2, ShopId = 2 },
                new Worker { Id = 3, Name = "Petro", Surname = "Kovalenko", Salary = 1800,
                    Email = "petro@gmail.com", PhoneNumber = "+380654321987", PositionId = 3, ShopId = 3 }
            });
        }
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Clothes" },
                new Category { Id = 2, Name = "Electronics" },
                new Category { Id = 3, Name = "Products" }
            });
        }
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { Id = 1, Name = "T-shirt", Price = 300, Discount = 0.1f,
                              CategoryId = 1, Quantity = 50, IsInStock = true },
                new Product { Id = 2, Name = "TV", Price = 5000, Discount = 0.2f,
                              CategoryId = 2, Quantity = 20, IsInStock = true },
                new Product { Id = 3, Name = "Bread", Price = 20, Discount = 0.0f,
                              CategoryId = 3, Quantity = 100, IsInStock = true }
            });
        }
    }
}
