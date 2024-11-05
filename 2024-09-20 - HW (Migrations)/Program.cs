using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace _2024_09_20___HW__Migrations_
{
    internal class Program
    {
        public static void TracksAboveAVG(MusicDbContext dbContext)
        {
            var tracks = dbContext.Tracks.Select(t => t);
            double listeningAVG = dbContext.Tracks.Average(t => t.Quantity);
            foreach (var item in tracks)
                if (listeningAVG <= item.Quantity)
                    WriteLine($"Name : {item.Name,-24}" +
                              $"Duration : {item.Duration.Minute}:" +
                                         $"{item.Duration.Second:00}    " +
                              $"Quantity : {item.Quantity}");
        }
        public static void Top3TracksByRating(MusicDbContext dbContext)
        {
            var top3 = dbContext.Albums.Include(al => al.Tracks).Include(al => al.Artist).OrderByDescending(t => t.Rating).Take(3);
            foreach (var item in top3)
                WriteLine($"Name : {item.Name}" +
                          $"\nYear of Release : {item.YearOfRelease.ToShortDateString()}" +
                          $"\nRating : {item.Rating}\n");
        }
        public static void TrackSearchByName(MusicDbContext dbContext, string str)
        {
            var tracks = dbContext.Tracks.Where(t => t.Name.Contains(str));
            foreach (var item in tracks)
                WriteLine($"Name : {item.Name,-24}" +
                              $"Duration : {item.Duration.Minute}:" +
                                         $"{item.Duration.Second:00}    " +
                              $"Quantity : {item.Quantity}");
        }
        static void Main(string[] args)
        {
            MusicDbContext dbContext = new MusicDbContext();

            //GetTracksAboveAVG(dbContext);

            //Top3TracksByRating(dbContext);

            string str = "Do";
            TrackSearchByName(dbContext, str);
        }
    }
}
