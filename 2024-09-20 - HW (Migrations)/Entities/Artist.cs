using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
