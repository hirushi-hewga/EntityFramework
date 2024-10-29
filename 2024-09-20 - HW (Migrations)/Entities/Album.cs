using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Album
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateOnly YearOfRelease { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public int Rating { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
