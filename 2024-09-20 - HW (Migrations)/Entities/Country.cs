using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
