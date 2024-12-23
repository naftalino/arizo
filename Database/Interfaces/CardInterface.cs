using bot.Database.Models;

namespace bot.Database.Interfaces
{
public interface ICardInterface
{
    Card CreateCard(Card card);
    Card? DeleteCard(int CardId);
    Card? UpdateCard(int CardId);
    Card? GetCard(int CardId);
    List<Card> GetAllCards();
    int HowManyUsersHaveCard(int CardId);
}
}