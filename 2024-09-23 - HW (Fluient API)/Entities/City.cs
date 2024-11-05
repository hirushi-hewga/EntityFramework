namespace _2024_09_23___HW__Fluient_API_.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
