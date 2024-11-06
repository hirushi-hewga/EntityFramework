using Microsoft.EntityFrameworkCore;
using Shop_Data_Access;
using static System.Console;

namespace _2024_09_25___Lesson__Loading_Data_
{
    internal class Program
    {
        private static ShopDbContext GetDbContext() => new ShopDbContext();

        static void Main(string[] args)
        {
            var workers = GetDbContext().Workers
                .Include(w => w.Position)
                .OrderBy(w => w.Name);

            WriteLine("Workers :");
            foreach (var item in workers)
            {
                WriteLine($"| Fullname : {item.Name} {item.Surname} ,  Email : {item.Email} ,  " +
                    $"Phone number : {item.PhoneNumber} ,  Position : {item.Position?.Name}");
            }

            var product = GetDbContext().Products.Find(1);
            GetDbContext().Entry(product).Reference(p => p.Category).Load();
            WriteLine($"Name : {product.Name} ,  Category : {product.Category?.Name}");






            /*
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
            WriteLine("\nShops :");
            foreach (var item in GetDbContext().Shops)
            {
                Write($"| Name : {item.Name} ,  Address : {item.Address} ,  ");
                if (item.ParkingArea != null) WriteLine($"Parking area : {item.ParkingArea}");
            }
            WriteLine("\nWorkers :");
            foreach (var item in GetDbContext().Workers)
            {
                WriteLine($"| Fullname : {item.Name} {item.Surname} ,  Email : {item.Email} ,  " +
                    $"Phone number : {item.PhoneNumber}");
            }
            WriteLine("\nPositions :");
            foreach (var item in GetDbContext().Positions)
            {
                WriteLine($"| Name : {item.Name}");
            }
            WriteLine("\nProducts :");
            foreach (var item in GetDbContext().Products)
            {
                WriteLine($"| Name : {item.Name} ,  Price : {item.Price} ,  Discount : {item.Discount}");
            }
            WriteLine("\nCategories :");
            foreach (var item in GetDbContext().Categories)
            {
                WriteLine($"| Name : {item.Name}");
            }
            */
        }
    }
}
