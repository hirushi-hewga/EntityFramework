using Bookstore_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_Data_Access.Helpers
{
    public static class DbInitializer
    {
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
            new Book { BookId = 1, BookName = "The Great Gatsby", NumberOfPages = 180, YearOfRelease = new DateTime(1925, 4, 10), Cost = 10.99f, Price = 15.99f, ContinuationBook = "", AuthorId = 1, PublisherId = 1, GenreId = 1 },
            new Book { BookId = 2, BookName = "Tender Is the Night", NumberOfPages = 304, YearOfRelease = new DateTime(1934, 4, 12), Cost = 12.99f, Price = 18.99f, ContinuationBook = "The Great Gatsby", AuthorId = 1, PublisherId = 1, GenreId = 1 },
            new Book { BookId = 3, BookName = "Becoming", NumberOfPages = 400, YearOfRelease = new DateTime(2018, 11, 13), Cost = 15.99f, Price = 22.99f, ContinuationBook = "", AuthorId = 2, PublisherId = 2, GenreId = 2 },
            new Book { BookId = 4, BookName = "Educated", NumberOfPages = 334, YearOfRelease = new DateTime(2018, 2, 20), Cost = 16.50f, Price = 24.99f, ContinuationBook = "", AuthorId = 3, PublisherId = 2, GenreId = 2 },
            new Book { BookId = 5, BookName = "1984", NumberOfPages = 328, YearOfRelease = new DateTime(1949, 6, 8), Cost = 13.50f, Price = 20.00f, ContinuationBook = "", AuthorId = 4, PublisherId = 3, GenreId = 3 },
            new Book { BookId = 6, BookName = "To Kill a Mockingbird", NumberOfPages = 281, YearOfRelease = new DateTime(1960, 7, 11), Cost = 10.99f, Price = 15.99f, ContinuationBook = "", AuthorId = 5, PublisherId = 3, GenreId = 4 },
            new Book { BookId = 7, BookName = "The Catcher in the Rye", NumberOfPages = 214, YearOfRelease = new DateTime(1951, 7, 16), Cost = 11.99f, Price = 17.99f, ContinuationBook = "", AuthorId = 6, PublisherId = 4, GenreId = 1 },
            new Book { BookId = 8, BookName = "The Diary of a Young Girl", NumberOfPages = 283, YearOfRelease = new DateTime(1947, 6, 25), Cost = 12.50f, Price = 18.50f, ContinuationBook = "", AuthorId = 7, PublisherId = 5, GenreId = 2 },
            new Book { BookId = 9, BookName = "Sapiens: A Brief History of Humankind", NumberOfPages = 443, YearOfRelease = new DateTime(2011, 1, 1), Cost = 18.99f, Price = 27.99f, ContinuationBook = "", AuthorId = 8, PublisherId = 6, GenreId = 5 },
            });
        }

        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
            new Author { AuthorId = 1, AuthorName = "F. Scott", AuthorSurname = "Fitzgerald" },
            new Author { AuthorId = 2, AuthorName = "Michelle", AuthorSurname = "Obama" },
            new Author { AuthorId = 3, AuthorName = "Tara", AuthorSurname = "Westover" },
            new Author { AuthorId = 4, AuthorName = "George", AuthorSurname = "Orwell" },
            new Author { AuthorId = 5, AuthorName = "Harper", AuthorSurname = "Lee" },
            new Author { AuthorId = 6, AuthorName = "J.D.", AuthorSurname = "Salinger" },
            new Author { AuthorId = 7, AuthorName = "Anne", AuthorSurname = "Frank" },
            new Author { AuthorId = 8, AuthorName = "Yuval Noah", AuthorSurname = "Harari" },
            });
        }

        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
            new Publisher { PublisherId = 1, PublisherName = "Scribner" },
            new Publisher { PublisherId = 2, PublisherName = "Crown Publishing Group" },
            new Publisher { PublisherId = 3, PublisherName = "Harcourt Brace Jovanovich" },
            new Publisher { PublisherId = 4, PublisherName = "Little, Brown and Company" },
            new Publisher { PublisherId = 5, PublisherName = "J.B. Lippincott & Co." },
            new Publisher { PublisherId = 6, PublisherName = "HarperCollins" },
            new Publisher { PublisherId = 7, PublisherName = "Viking Press" },
            new Publisher { PublisherId = 8, PublisherName = "Harper" },
            });
        }

        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
            new Genre { GenreId = 1, GenreName = "Classic Literature" },
            new Genre { GenreId = 2, GenreName = "Memoir" },
            new Genre { GenreId = 3, GenreName = "Dystopian Fiction" },
            new Genre { GenreId = 4, GenreName = "Southern Gothic" },
            new Genre { GenreId = 5, GenreName = "Non-Fiction" },
            });
        }
    }
}
