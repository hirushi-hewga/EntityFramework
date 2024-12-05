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
            LoadDate();
            LoadContinuation();
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

        public void LoadContinuation()
        {
            continuation_combobox.Items.Clear();
            List<Book> books = dbContext.Books.ToList();
            foreach (var item in books) continuation_combobox.Items.Add(item.BookName);
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
            InputDialogWindow2 inputDialog = new InputDialogWindow2("Назва видавця :");

            string publisher = null;

            if (inputDialog.ShowDialog() == true)
            {
                publisher = inputDialog.Content;
            }

            if (!string.IsNullOrEmpty(publisher))
            {
                dbContext.Publishers.Add(new Publisher()
                {
                    PublisherName = publisher
                });
                dbContext.SaveChanges();
                LoadPublishers();
                return;
            }
            MessageBox.Show("Invalid Input");

        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            InputDialogWindow2 inputDialog = new InputDialogWindow2("Назва жанру :");

            string genre = null;

            if (inputDialog.ShowDialog() == true)
            {
                genre = inputDialog.Content;
            }

            if (!string.IsNullOrEmpty(genre))
            {
                dbContext.Genres.Add(new Genre()
                {
                    GenreName = genre
                });
                dbContext.SaveChanges();
                LoadGenres();
                return;
            }
            MessageBox.Show("Invalid Input");
        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            InputDialogWindow inputDialog = new InputDialogWindow();

            string name = null;
            string surname = null;

            if (inputDialog.ShowDialog() == true)
            {
                name = inputDialog.FirstName;
                surname = inputDialog.LastName;
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                dbContext.Authors.Add(new Author()
                {
                    AuthorName = name,
                    AuthorSurname = surname
                });
                dbContext.SaveChanges();
                LoadAuthors();
                return;
            }
            MessageBox.Show("Invalid Input");
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string bookName = bookName_textBox.Text;
                int numberOfPages = string.IsNullOrWhiteSpace(numberOfPages_textBox.Text) ? 0 : int.Parse(numberOfPages_textBox.Text);
                int year = year_combobox.SelectedItem == null ? 0 : int.Parse(year_combobox.SelectedItem.ToString()!);
                int month = month_combobox.SelectedItem == null ? 0 : int.Parse(month_combobox.SelectedItem.ToString()!);
                int day = day_combobox.SelectedItem == null ? 0 : int.Parse(day_combobox.SelectedItem.ToString()!);
                string continuation = continuation_combobox.SelectedItem == null ? "-" : continuation_combobox.SelectedItem.ToString()!;
                string publisher = publisher_combobox.SelectedItem == null ? "" : publisher_combobox.SelectedItem.ToString()!;
                string genre = genre_combobox.SelectedItem == null ? "" : genre_combobox.SelectedItem.ToString()!;
                string author = author_combobox.SelectedItem == null ? "" : author_combobox.SelectedItem.ToString()!;
                float cost = string.IsNullOrWhiteSpace(Cost_textBox.Text) ? 0f : float.Parse(Cost_textBox.Text);
                float price = string.IsNullOrWhiteSpace(Price_textBox.Text) ? 0f : float.Parse(Price_textBox.Text);
                bool isValidData = false;

                if (string.IsNullOrWhiteSpace(bookName)) MessageBox.Show("Назву книги не ввевдено");
                else if (numberOfPages <= 0) MessageBox.Show("Кількість сторінок повинна бути більше 0.");
                else if (year == 0) MessageBox.Show("Рік не вибрано");
                else if (month == 0) MessageBox.Show("Місяць не вибрано");
                else if (day == 0) MessageBox.Show("День не вибрано");
                else if (string.IsNullOrWhiteSpace(publisher)) MessageBox.Show("Видавця не вибрано");
                else if (string.IsNullOrWhiteSpace(genre)) MessageBox.Show("Жанр не вибрано");
                else if (string.IsNullOrWhiteSpace(author)) MessageBox.Show("Автора не вибрано");
                else if (cost <= 0f) MessageBox.Show("Вартість повинна бути більше 0.");
                else if (price <= 0f) MessageBox.Show("Ціна повинна бути більше 0.");
                else isValidData = true;

                if (isValidData)
                {
                    DateTime date;
                    if (!DateTime.TryParse($"{year}-{month}-{day}", out date))
                    {
                        MessageBox.Show("Невірно введено дату");
                        return;
                    }

                    dbContext.Books.Add(new Book()
                    {
                        BookName = bookName,
                        NumberOfPages = numberOfPages,
                        YearOfRelease = date,
                        Cost = cost,
                        Price = price,
                        ContinuationBook = continuation,
                        AuthorId = dbContext.Authors.FirstOrDefault(a => $"{a.AuthorName} {a.AuthorSurname}" == author).AuthorId,
                        PublisherId = dbContext.Publishers.FirstOrDefault(p => p.PublisherName == publisher).PublisherId,
                        GenreId = dbContext.Genres.FirstOrDefault(g => g.GenreName == genre).GenreId
                    });

                    dbContext.SaveChanges();
                    MessageBox.Show("Книгу додано");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
