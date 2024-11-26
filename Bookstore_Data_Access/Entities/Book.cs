namespace Bookstore_Data_Access.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime YearOfRelease { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public string ContinuationBook { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
