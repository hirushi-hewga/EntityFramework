namespace Bookstore_Data_Access.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
