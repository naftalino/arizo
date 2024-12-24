using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface ICollectionInterface
    {
        bool InsertCardOnCollection(Collection collection);
        bool RemoveCardFromCollection(Collection collection);
        List<Card> GetCardsFromCollection(long UserId);
        List<Card> GetCardsFromCollectionByRarity(long UserId, string Rarity);
        List<Card> GetCardsFromCollectionByPopularity(long UserId, int Popularity);
        List<Card> GetCardsFromCollectionByLimitedEdition(long UserId, bool IsLimitedEdition);
        List<Card> GetCardsFromCollectionByCanBeSold(long UserId, bool CanBeSold);
        List<Card> GetCardsFromCollectionBySerie(long UserId, int SerieId);
        List<Card> GetCardsFromCollectionByPrice(long UserId, int Price);
        int HowManyCardsUserHas(long UserId);
        bool EnableAsTradeable(long UserId, int CardId);
        bool DisableAsTradeable(long UserId, int CardId);
        List<Card> GetTradeableCards(long UserId);
    }
}