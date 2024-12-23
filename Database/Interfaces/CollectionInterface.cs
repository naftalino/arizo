using bot.Database.Models;

namespace bot.Database.Interfaces
{
public interface ICollectionInterface
{
    bool InsertCardOnCollection(int UserId, int CardId);
    bool RemoveCardFromCollection(int UserId, int CardId);
    List<Card> GetCardsFromCollection(int UserId);
    List<Card> GetCardsFromCollectionByRarity(int UserId, string Rarity);
    List<Card> GetCardsFromCollectionByPopularity(int UserId, int Popularity);
    List<Card> GetCardsFromCollectionByLimitedEdition(int UserId, bool IsLimitedEdition);
    List<Card> GetCardsFromCollectionByCanBeSold(int UserId, bool CanBeSold);
    List<Card> GetCardsFromCollectionBySerie(int UserId, int SerieId);
    List<Card> GetCardsFromCollectionByPrice(int UserId, int Price);
    int HowManyCardsUserHas(int UserId);
    bool EnableAsTradeable(int UserId, int CardId);
    bool DisableAsTradeable(int UserId, int CardId);
    List<Card> GetTradeableCards(int UserId);
}
}