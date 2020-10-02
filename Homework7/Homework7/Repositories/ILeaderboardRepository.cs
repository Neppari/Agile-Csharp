using Homework7.Models;
using System.Collections.Generic;

namespace Homework7.Repositories
{
    public interface ILeaderboardRepository
    {
        void AddLevel(Level level);
        void AddPlayer(Player player);
        void AddScore(Score score, int levelId);
        void DeleteScore(int id);
        List<Level> GetLevels();
        List<Player> GetPlayers();
        Score GetScore(int id);
        List<Score> GetScores(int levelId);
    }
}