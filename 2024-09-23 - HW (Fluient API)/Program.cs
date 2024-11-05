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
        }
    }
}
