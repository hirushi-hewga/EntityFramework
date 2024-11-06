﻿namespace _2024_09_25___Lesson__Loading_Data_.Entities
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
