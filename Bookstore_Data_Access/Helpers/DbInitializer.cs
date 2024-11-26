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
            });
        }

        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
            });
        }

        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
            });
        }

        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
            });
        }
    }
}
