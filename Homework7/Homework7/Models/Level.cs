using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Score> Scores { get; set; }
    }
}
