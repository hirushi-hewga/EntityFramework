using System.ComponentModel.DataAnnotations;

namespace _2024_09_23___Lesson__Fluient_API_.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}