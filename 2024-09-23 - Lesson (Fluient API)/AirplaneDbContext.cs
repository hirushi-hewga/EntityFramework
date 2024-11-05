using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using _2024_09_23___Lesson__Fluient_API_.Entities;
using _2024_09_23___Lesson__Fluient_API_.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace _2024_09_23___Lesson__Fluient_API_
{
    public class AirplaneDbContext : DbContext
    {
        // Collections
        // Clients
        // Flights
        // Airplane

        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                         Initial Catalog=AirportDb_0918
                                          Integrated Security=True;
                                          Connect Timeout=2;
                                          Encrypt=True;
                                          Trust Server Certificate=True;
                                          Application Intent=ReadWrite;
                                          Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Validation
            //Fluent API configuration
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            // set Primary Key
            modelBuilder.Entity<Flight>().HasKey(f => f.Number);

            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureCity)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalCity)
                .IsRequired()
                .HasMaxLength(100);




            modelBuilder.Entity<Airplane>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airplane)
                .HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Flights)
                .WithMany(f => f.Clients);




            //Initialization Seeder
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
        }
    }
}