using bot.Database.Models;

namespace bot.Database.Interfaces
{
public interface ICardInterface
{
    Card CreateCard(string name, string description, string imageUrl, string rarity, bool canBeSold, int price, bool isLimitedEdition, int popularity, int serieId);
    Card DeleteCard(int CardId);
    Card UpdateCard(int CardId);
    Card GetCard(int CardId);
    List<Card> GetCardsBySerie(int SerieId);
    List<Card> GetCardsByRarity(string Rarity);
    List<Card> GetCardsByPopularity(int Popularity);
    List<Card> GetCardsByLimitedEdition(bool IsLimitedEdition);
    List<Card> GetCardsByCanBeSold(bool CanBeSold);
    List<Card> GetAllCards();
    int HowManyUsersHaveCard(int CardId);
}
}