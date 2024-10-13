using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_16___Lesson__Intro_to_EntityFramework_
{
    public class AirplaneDbContext
    {
        // Collections
        // Clients
        // Flights
        // Airplane
    }
    //Entities
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
    class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    class Flight
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
