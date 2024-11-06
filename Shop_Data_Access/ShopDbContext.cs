using Microsoft.EntityFrameworkCore;
using Shop_Data_Access.Entities;
using Shop_Data_Access.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Data_Access
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=ShopDb14222.mssql.somee.com;
                                          packet size=4096;
                                          user id=HCisijsjJjd_SQLLogin_1;
                                          pwd=h1br7xn9bu;
                                          data source=ShopDb14222.mssql.somee.com;
                                          persist security info=False;
                                          initial catalog=ShopDb14222;
                                          TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Validation

            #region Positions

            modelBuilder.Entity<Position>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .HasMany(p => p.Workers)
                .WithOne(w => w.Position)
                .HasForeignKey(w => w.PositionId);

            #endregion

            #region Workers

            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(w => w.Surname)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(w => w.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(w => w.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region Shops

            modelBuilder.Entity<Shop>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Shop>()
                .Property(w => w.Address)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Workers)
                .WithOne(w => w.Shop)
                .HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Products)
                .WithMany(w => w.Shops)
                .UsingEntity(j => j.ToTable("ProductShops"));

            #endregion

            #region Cities

            modelBuilder.Entity<City>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(c => c.Shops)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId);

            #endregion

            #region Countries

            modelBuilder.Entity<Country>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);

            #endregion

            #region Products

            modelBuilder.Entity<Product>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Categories

            modelBuilder.Entity<Category>()
                .Property(w => w.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(false);

            #endregion


            //Initialization

            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedShops();
            modelBuilder.SeedPositions();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
        }
    }
}
