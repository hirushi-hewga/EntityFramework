using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static System.Console;

namespace _2024_09_18___HW__Intro_to_EntityFramework_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext dbContext = new MusicDbContext();
            WriteLine("Countries :");
            foreach (var item in dbContext.Countries)
            {
                WriteLine($"| {item.Name}");
            }
            WriteLine("\nArtists :");
            foreach (var item in dbContext.Artists)
            {
                WriteLine($"| {item.Name} {item.Surname}");
            }
            WriteLine("\nGenres :");
            foreach (var item in dbContext.Genres)
            {
                WriteLine($"| {item.Name}");
            }
            WriteLine("\nAlbums :");
            foreach (var item in dbContext.Albums)
            {
                WriteLine($"| {item.Name}");
            }
            WriteLine("\nTracks :");
            foreach (var item in dbContext.Tracks)
            {
                WriteLine($"| {item.Name, -22} {item.Duration.Minute}:{item.Duration.Second:00}");
            }
            WriteLine("\nCategories :");
            foreach (var item in dbContext.Categories)
            {
                WriteLine($"| {item.Name}");
            }
            WriteLine("\nPlaylists :");
            foreach (var item in dbContext.Playlists)
            {
                WriteLine($"| {item.Name}");
            }
        }
    }
}
