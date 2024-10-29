using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
