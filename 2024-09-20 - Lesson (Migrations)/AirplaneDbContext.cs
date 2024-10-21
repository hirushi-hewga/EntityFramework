using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using _2024_09_20___Lesson__Migrations_.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace _2024_09_20___Lesson__Migrations_
{
    public class AirplaneDbContext : DbContext
    {
        // Collections
        // Clients
        // Flights
        // Airplane

        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                         Initial Catalog=AirportDb_0918
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
            //Initialization
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane { Id = 1, Model = "AN 225", MaxPassangers = 300 },
                new Airplane { Id = 2, Model = "Mria", MaxPassangers = 100 },
                new Airplane { Id = 3, Model = "Boeing 747", MaxPassangers = 200 }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Number = 1,
                    DepartureCity = "Rivne",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 1
                },
                new Flight()
                {
                    Number = 2,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 2
                },
                new Flight()
                {
                    Number = 3,
                    DepartureCity = "Warshaw",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 3
                },
            });
        }
    }
}

