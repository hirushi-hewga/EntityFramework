using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace _2024_09_20___HW__Migrations_
{
    internal class Program
    {
        public static void Tracks(MusicDbContext dbContext)
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
        static void Main(string[] args)
        {
            MusicDbContext dbContext = new MusicDbContext();

            // 1
            Tracks(dbContext);

            #region 2


            //foreach (var item in dbContext.Artists)
            //{
            //    WriteLine($"{item.Name} :");
            //    var tracks = dbContext.Albums.Include(al => al.Artist)
            //        .Include(ar => ar.Tracks).ToList();
            //}


            #endregion
        }
    }
}
