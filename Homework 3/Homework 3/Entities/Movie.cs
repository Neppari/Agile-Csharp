using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_3.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        public Movie(int id, string name, string description, int length)
        {
            Id = id;
            Name = name;
            Description = description;
            Length = length;
        }
    }
}
