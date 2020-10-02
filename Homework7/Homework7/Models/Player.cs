using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int CountryCode { get; set; }

        public ICollection<Score> Scores { get; set; }
    }
}
