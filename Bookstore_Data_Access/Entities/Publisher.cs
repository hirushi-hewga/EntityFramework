namespace Bookstore_Data_Access.Entities
{
    public class Publisher
    {
        public int AuthorId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
