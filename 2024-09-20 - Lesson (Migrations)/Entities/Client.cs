using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___Lesson__Migrations_.Entities
{
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

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}

