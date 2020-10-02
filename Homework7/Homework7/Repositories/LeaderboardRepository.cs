using Homework7.Contexts;
using Homework7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Repositories
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly LeaderboardContext _context;
        public LeaderboardRepository(LeaderboardContext context)
        {
            _context = context;
        }

        #region Score table
        //get score
        public Score GetScore(int id) =>
            _context.Scores.SingleOrDefault(s => s.Id == id);

        //get all scores
        public List<Score> GetScores(int levelId)
        {
            var scores = _context.Scores
                .Where(s => s.LevelId == levelId)
                .ToList();

            return scores;
        }

        //add new score
        public void AddScore(Score score, int levelId)
        {
            score.LevelId = levelId;
            _context.Scores.Add(score);
            _context.SaveChanges();
        }

        //delete score
        public void DeleteScore(int id)
        {
            _context.Scores.Remove(GetScore(id));
            _context.SaveChanges();
        }
        #endregion

        #region Level table
        //get all levels
        public List<Level> GetLevels() =>
            _context.Levels.ToList();

        //add new level
        public void AddLevel(Level level)
        {
            _context.Levels.Add(level);
            _context.SaveChanges();
        }
        #endregion

        #region Player table
        //get all players
        public List<Player> GetPlayers() =>
            _context.Players.ToList();

        //add new player
        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
        #endregion
    }
}
