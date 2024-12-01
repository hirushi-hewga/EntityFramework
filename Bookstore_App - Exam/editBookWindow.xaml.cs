using Bookstore_Data_Access.Entities;
using Bookstore_Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bookstore_App___Exam
{
    /// <summary>
    /// Interaction logic for editBookWindow.xaml
    /// </summary>
    public partial class editBookWindow : Window
    {
        private string bookName;
        public BookstoreDbContext dbContext = new BookstoreDbContext();
        public editBookWindow(string bookName)
        {
            this.bookName = bookName;
            InitializeComponent();
            LoadPublishers();
            LoadAuthors();
            LoadGenres();
        }

        public void LoadPublishers()
        {
            publisher_combobox.Items.Clear();
            List<Publisher> publishers = dbContext.Publishers.ToList();
            foreach (var item in publishers) publisher_combobox.Items.Add(item.PublisherName);
        }

        public void LoadAuthors()
        {
            author_combobox.Items.Clear();
            List<Author> authors = dbContext.Authors.ToList();
            foreach (var item in authors) author_combobox.Items.Add($"{item.AuthorName} {item.AuthorSurname}");
        }

        public void LoadGenres()
        {
            genre_combobox.Items.Clear();
            List<Genre> genres = dbContext.Genres.ToList();
            foreach (var item in genres) genre_combobox.Items.Add(item.GenreName);
        }

        private void addPublisherButton_Click(object sender, RoutedEventArgs e)
        {
            //addBookWindow window = new addBookWindow();
            //window.ShowDialog();
            //LoadBooks();
        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            //addBookWindow window = new addBookWindow();
            //window.ShowDialog();
            //LoadBooks();
        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            //addBookWindow window = new addBookWindow();
            //window.ShowDialog();
            //LoadBooks();
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
