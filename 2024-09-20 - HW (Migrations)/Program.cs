using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace _2024_09_20___HW__Migrations_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext dbContext = new MusicDbContext();

            #region 1

            /*
            var tracks = dbContext.Tracks.Where(t => t.Quantity >= 30000);
            foreach (var item in tracks)
            {
                WriteLine($"Name : {item.Name,-24}" +
                          $"Duration : {item.Duration.Minute}:" +
                                     $"{item.Duration.Second:00}    " +
                          $"Quantity : {item.Quantity}");
            }
            */

            #endregion

            #region 2


            foreach (var item in dbContext.Artists)
            {
                WriteLine($"{item.Name} :");
                var tracks = dbContext.Artists.Join(dbContext.Albums, ar => ar.Id, al => al.ArtistId, (ar, al) => new {  });
            }


            #endregion
        }
    }
}
