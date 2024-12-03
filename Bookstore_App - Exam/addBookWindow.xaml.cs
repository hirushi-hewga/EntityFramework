using System;
using Bookstore_Data_Access;
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
using Bookstore_Data_Access.Entities;

namespace Bookstore_App___Exam
{
    /// <summary>
    /// Interaction logic for addBookWindow.xaml
    /// </summary>
    public partial class addBookWindow : Window
    {
        public BookstoreDbContext dbContext = new BookstoreDbContext();
        public addBookWindow()
        {
            InitializeComponent();
            LoadPublishers();
            LoadAuthors();
            LoadGenres();
            LoadDate();
        }

        public void LoadDate()
        {
            year_combobox.Items.Clear();
            month_combobox.Items.Clear();
            day_combobox.Items.Clear();
            for (int i = 1950; i <= DateTime.Now.Year; i++) year_combobox.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++) month_combobox.Items.Add(i.ToString());
            for (int i = 1; i <= 31; i++) day_combobox.Items.Add(i.ToString());
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
            //LoadPublishers();
        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            //addBookWindow window = new addBookWindow();
            //window.ShowDialog();
            //LoadGenres();
        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            //addBookWindow window = new addBookWindow();
            //window.ShowDialog();
            //LoadAuthors();
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
