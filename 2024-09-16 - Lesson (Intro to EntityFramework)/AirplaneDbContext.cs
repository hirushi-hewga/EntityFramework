﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_18___Lesson__Intro_to_EntityFramework_
{
    public class AirplaneDbContext : DbContext
    {
        // Collections
        // Clients
        // Flights
        // Airplane

        public AirplaneDbContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
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
    //Entities

    [Table("Passangers")]
    public class Client
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] // null => not null
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Flight
    {
        //Primary key naming : Id/id/ID/EntityName+Id
        [Key] // set primary key
        public int Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        // Relationship type : one to many (1..*)
        public Airplane Airplane { get; set; }
        //Foreight key naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; } // foreight key
        // Relationship type : many to many (*..*)
        public ICollection<Client> Clients { get; set; }
    }
}
