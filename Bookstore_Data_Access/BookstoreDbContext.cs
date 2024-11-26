using Bookstore_Data_Access.Entities;
using Bookstore_Data_Access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_Data_Access
{
    public partial class BookstoreDbContext : DbContext
    {
        /*public DbSet<Account> Accounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Flight> Flights { get; set; }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=Bookstore_Exam.mssql.somee.com;
                                            packet size=4096;
                                            user id=EFiopjIOJIEDV_SQLLogin_1;
                                            pwd=vfjplt2j4f;
                                            data source=Bookstore_Exam.mssql.somee.com;
                                            persist security info=False;initial catalog=Bookstore_Exam;
                                            TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Validation

            #region Book

            modelBuilder.Entity<Book>()
                .Property(b => b.BookName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.ContinuationBook)
                .HasMaxLength(150);

            #endregion

            #region Author

            modelBuilder.Entity<Author>()
                .Property(a => a.AuthorName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.AuthorSurname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            #endregion

            #region Publisher

            modelBuilder.Entity<Publisher>()
                .Property(p => p.PublisherName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);

            #endregion

            #region Genre

            modelBuilder.Entity<Genre>()
                .Property(g => g.GenreName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId);

            #endregion


            // Initialization

            modelBuilder.SeedBooks();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedGenres();
        }
    }
}
