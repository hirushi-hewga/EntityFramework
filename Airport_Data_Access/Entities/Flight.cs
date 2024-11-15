namespace Airport_Data_Access.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public City ArrivalCity { get; set; }
        public int ArrivalCityId { get; set; }
        public Aircraft Aircraft { get; set; }
        public int AircraftId { get; set; }
    }
}
