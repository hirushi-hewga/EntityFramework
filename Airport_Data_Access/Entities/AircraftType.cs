namespace Airport_Data_Access.Entities
{
    public class AircraftType
    {
        public int AircraftTypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set; }
    }
}
