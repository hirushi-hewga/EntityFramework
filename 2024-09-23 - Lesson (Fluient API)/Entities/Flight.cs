using System.ComponentModel.DataAnnotations;

namespace _2024_09_23___Lesson__Fluient_API_.Entities
{
    public class Flight
    {
        public int Number { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }

        //Navigation properties
        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}