using bot.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using bot.Database.Models;

namespace bot.Database.Repositories
{
    public class CollectionRepository : ICollectionInterface
    {
        private readonly DatabaseContext _context;
        public CollectionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool InsertCardOnCollection(Collection collection)
        {
            _context.Collections.Add(collection);
            return true;
        }

        public bool RemoveCardFromCollection(Collection collection)
        {
            _context.Collections.Remove(collection);
            return true;
        }

        public List<Card> GetCardsFromCollection(long userId)
        {
            return _context.Collections
                .Where(c => c.UserId == userId)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionByRarity(long userId, string rarity)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.Rarity == rarity)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionByPopularity(long userId, int popularity)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.Popularity == popularity)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionByLimitedEdition(long userId, bool isLimitedEdition)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.IsLimitedEdition == isLimitedEdition)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionByCanBeSold(long userId, bool canBeSold)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.CanBeSold == canBeSold)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionBySerie(long userId, int serieId)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.SerieId == serieId)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public List<Card> GetCardsFromCollectionByPrice(long userId, int price)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Card.Price == price)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }

        public int HowManyCardsUserHas(long userId)
        {
            return _context.Collections
                .Where(c => c.UserId == userId)
                .Count();
        }

        public bool EnableAsTradeable(long userId, int cardId)
        {
            var collection = _context.Collections
                .Where(c => c.UserId == userId && c.CardId == cardId)
                .FirstOrDefault();

            collection.Tradeable = true;
            return true;
        }

        public bool DisableAsTradeable(long userId, int cardId)
        {
            var collection = _context.Collections
                .Where(c => c.UserId == userId && c.CardId == cardId)
                .FirstOrDefault();

            collection.Tradeable = false;
            return true;
        }

        public List<Card> GetTradeableCards(long userId)
        {
            return _context.Collections
                .Where(c => c.UserId == userId && c.Tradeable == true)
                .Include(c => c.Card)
                .Select(c => c.Card)
                .ToList();
        }
    }
}