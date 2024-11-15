using System.ComponentModel.DataAnnotations;

namespace Airport_Data_Access.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
