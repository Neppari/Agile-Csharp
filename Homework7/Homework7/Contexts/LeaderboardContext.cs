using Homework7.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Homework7.Contexts
{
    public class LeaderboardContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Level> Levels { get; set; }

        public LeaderboardContext(DbContextOptions<LeaderboardContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>()
                .HasOne<Level>(x => x.Level)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Score>()
                .HasOne<Player>(x => x.Player)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, CountryCode = 1, Username = "Player1" },
                new Player { Id = 2, CountryCode = 1, Username = "Player2" },
                new Player { Id = 3, CountryCode = 2, Username = "Player3" }
                );

            modelBuilder.Entity<Level>().HasData(
                new Level { Id = 1, Name = "Bungle Jungle" },
                new Level { Id = 2, Name = "Frosty Peaks" },
                new Level { Id = 3, Name = "Daily Dash" }
                );

            modelBuilder.Entity<Score>().HasData(
                new Score
                {
                    Id = 1,
                    Timestamp = DateTime.Now,
                    TimeInSeconds = 120,
                    Highscore = 550,
                    LevelId = 1,
                    PlayerId = 2
                }
                );
        }
    }
}
