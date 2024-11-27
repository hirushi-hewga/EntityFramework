using Bookstore_Data_Access;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookstore_App___Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Book_
    {
        public string Name { get; set; }
        public string NumberOfPages { get; set; }
        public string YearOfRelease { get; set; }
        public string ContinuationBook { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }

    public partial class MainWindow : Window
    {
        public BookstoreDbContext dbContext = new BookstoreDbContext();
        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        public void LoadBooks()
        {
            listBox.ItemsSource = GetBookDetails();
        }

        public List<Book_> GetBookDetails()
        {
            return dbContext.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Select(b => new Book_()
                {
                    Name = b.BookName,
                    NumberOfPages = b.NumberOfPages.ToString(),
                    YearOfRelease = b.YearOfRelease.ToString("yyyy-MM-dd"),
                    ContinuationBook = b.ContinuationBook,
                    Genre = b.Genre.GenreName,
                    Author = $"{b.Author.AuthorName} {b.Author.AuthorSurname}",
                    Publisher = b.Publisher.PublisherName
                })
                .ToList();
        }
    }
}