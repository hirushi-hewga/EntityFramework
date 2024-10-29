﻿using System.ComponentModel.DataAnnotations;

namespace _2024_09_20___HW__Migrations_.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
