namespace Bookstore_Data_Access.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
