using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2024_09_23___Lesson__Fluient_API_.Entities
{
    //Entities

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}