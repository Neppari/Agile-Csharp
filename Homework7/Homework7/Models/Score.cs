using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Models
{
    public class Score
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int TimeInSeconds { get; set; }
        public int Highscore { get; set; }

        public Player Player { get; set; }
        public int PlayerId { get; set; }

        public Level Level { get; set; }
        public int LevelId { get; set; }
    }
}
