namespace _2024_09_23___HW__Fluient_API_.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
