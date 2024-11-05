using static System.Console;

namespace _2024_09_23___HW__Fluient_API_
{
    internal class Program
    {
        private static ShopDbContext GetDbContext()
        {
            return new ShopDbContext();
        }

        static void Main(string[] args)
        {
            WriteLine("Countries :");
            foreach (var item in GetDbContext().Countries)
            {
                WriteLine($"| Name : {item.Name}");
            }
            WriteLine("\nCities :");
            foreach (var item in GetDbContext().Cities)
            {
                WriteLine($"| Name : {item.Name}");
            }
        }
    }
}
