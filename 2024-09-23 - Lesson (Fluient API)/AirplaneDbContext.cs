using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using _2024_09_23___Lesson__Fluient_API_.Entities;
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
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane { Id = 1, Model = "AN 225", MaxPassangers = 300 },
                new Airplane { Id = 2, Model = "Mria", MaxPassangers = 100 },
                new Airplane { Id = 3, Model = "Boeing 747", MaxPassangers = 200 }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Number = 1,
                    DepartureCity = "Rivne",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 1
                },
                new Flight()
                {
                    Number = 2,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 2
                },
                new Flight()
                {
                    Number = 3,
                    DepartureCity = "Warshaw",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,09,25),
                    ArrivalTime = new DateTime(2024,09,25),
                    AirplaneId = 3
                },
            });
        }
    }
}