using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_5.Models
{
    public class Entry
    {
        public enum Exercise
        {
            Cycling,
            Jogging,
            Walking,
            Dancing,
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Exercise ExerciseType { get; set; }
        public int Duration { get; set; }
    }
}
