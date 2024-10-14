namespace _2024_09_18___Lesson__Intro_to_EntityFramework_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext dbContext = new AirplaneDbContext();
            dbContext.Clients.Add(new Client()
            {
                Name = "Vova",
                Email = "vova@gmail.com",
                Birthday = new DateTime(2000,5,12)
            });
            dbContext.SaveChanges();


            foreach (var client in dbContext.Clients)
            {
                Console.WriteLine($"{client.Name} . {client.Email} . {client.Birthday}");
            }
            var filteredFlight = dbContext.Flights
                .Where(f => f.ArrivalCity == "Lviv")
                .OrderBy(f => f.ArrivalTime);
            foreach (var flight in filteredFlight)
            {
                Console.WriteLine($"{flight.ArrivalCity} - {flight.DepartureCity} - {flight.ArrivalTime}");
            }
        }
    }
}
