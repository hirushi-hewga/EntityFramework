using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static System.Console;

namespace _2024_09_18___HW__Intro_to_EntityFramework_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new MusicDbContext())
            {
                foreach (var item in dbContext.Countries)
                {
                    WriteLine($"Name : {item.Name}");
                }
            }
        }
    }
}
