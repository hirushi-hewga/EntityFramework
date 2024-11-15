using System.ComponentModel.DataAnnotations;

namespace Airport_Data_Access.Entities
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string AircraftModel { get; set; }
        public AircraftType AircraftType { get; set; }
        public int AircraftTypeId { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
