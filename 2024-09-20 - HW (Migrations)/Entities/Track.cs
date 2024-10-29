using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string Text { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
