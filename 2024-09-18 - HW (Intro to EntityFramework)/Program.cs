﻿using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace _2024_09_18___HW__Intro_to_EntityFramework_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext dbContext = new MusicDbContext();

            foreach (var item in dbContext)
            {

            }


        }
    }
}