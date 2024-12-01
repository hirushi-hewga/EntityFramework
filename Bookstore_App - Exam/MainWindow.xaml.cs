using Bookstore_Data_Access;
using Bookstore_Data_Access.Entities;
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
            LoadAuthors();
            LoadGenres();

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
                .OrderBy(b => b.Name)
                .ToList();
        }

        public void LoadAuthors()
        {
            List<Author> authors = dbContext.Authors.ToList();
            foreach (var item in authors) author_combobox.Items.Add($"{item.AuthorName} {item.AuthorSurname}");
        }

        public void LoadGenres()
        {
            List<Genre> genres = dbContext.Genres.ToList();
            foreach (var item in genres) genre_combobox.Items.Add(item.GenreName);
        }

        private void UpdateButtonState()
        {
            search_button.IsEnabled = (author_combobox.SelectedItem == null &&
                                genre_combobox.SelectedItem == null &&
                                string.IsNullOrEmpty(bookName_textBox.Text)) ? false : true;
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Book_> books_ = GetBookDetails();
            if (author_combobox.SelectedItem != null)
                books_ = books_.Where(b => b.Author == author_combobox.SelectedItem.ToString());
            if (genre_combobox.SelectedItem != null)
                books_ = books_.Where(b => b.Genre == genre_combobox.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(bookName_textBox.Text))
                books_ = books_.Where(b => b.Name.Contains(bookName_textBox.Text) || 
                                      b.Name.ToLower().Contains(bookName_textBox.Text) ||
                                      b.Name.ToUpper().Contains(bookName_textBox.Text));
            listBox.ItemsSource = books_ ?? null;
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            addBookWindow window = new addBookWindow();
            window.ShowDialog();
            LoadBooks();
        }

        private void editBookButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var book = button.DataContext as Book_;
            editBookWindow window = new editBookWindow(book.Name);
            window.ShowDialog();
            LoadBooks();
        }

        private void deleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var book = button.DataContext as Book_;
            dbContext.Books.Remove(dbContext.Books.FirstOrDefault(b => b.BookName == book.Name));
            dbContext.SaveChanges();
            LoadBooks();
        }
    }
}