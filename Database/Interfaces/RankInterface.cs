using bot.Database.Models;

namespace Database.Interfaces
{
    public interface IRankInterface
    {
        void AddRank(Rank rank);
        void UpdateRank(Rank rank);
        Rank GetRank(int id);
    }
}