using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
