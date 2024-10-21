using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___Lesson__Migrations_.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] // null => not null
        public string Model { get; set; }
        public int MaxPassangers { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}

