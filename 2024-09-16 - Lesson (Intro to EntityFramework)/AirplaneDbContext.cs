using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
    //Entities

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    public class Flight
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        // Relationship type : one to many (1..*)
        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; } // foreight key
        // Relationship type : many to many (*..*)
        public ICollection<Client> Clients { get; set; }
    }
}
