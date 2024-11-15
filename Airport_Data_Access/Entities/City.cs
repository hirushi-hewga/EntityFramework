using System.ComponentModel.DataAnnotations;

namespace Airport_Data_Access.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
