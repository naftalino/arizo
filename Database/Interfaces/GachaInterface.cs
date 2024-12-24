using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IGachaInterface
    {
        Card PerformSinglePull(int userId);
        IEnumerable<Card> PerformAutoPulls(int userId);
        int GetUserGachaCurrencyBalance(int userId);
        void AddGachaTickets(int userId, int amount);
        void DeductGachaTickets(int userId, int amount);
    }
}