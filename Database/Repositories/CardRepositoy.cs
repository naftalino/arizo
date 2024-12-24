using bot.Database.Interfaces;
using bot.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace bot.Database.Repositories
{
    public class CardRepository : ICardInterface
    {
        private readonly DbContext _context;

        public CardRepository(DbContext context)
        {
            _context = context;
        }

        public Card CreateCard(Card card)
        {
            _context.Add(card);
            _context.SaveChanges();
            return card;
        }

        public Card? DeleteCard(int CardId)
        {
            var card = _context.Find<Card>(CardId);
            if (card == null)
            {
                return null;
            }
            _context.Remove(card);
            _context.SaveChanges();
            return card;
        }

        public Card? UpdateCard(int CardId)
        {
            var card = _context.Find<Card>(CardId);
            if (card == null)
            {
                return null;
            }
            _context.Update(card);
            _context.SaveChanges();
            return card;
        }

        public Card? GetCard(int CardId)
        {
            var card = _context.Find<Card>(CardId);
            if (card == null)
            {
                return null;
            }
            return card;
        }

        public List<Card> GetAllCards()
        {
            return _context.Set<Card>().ToList();
        }

        public int HowManyUsersHaveCard(int CardId)
        {

            return _context.Set<Collection>()
            .Where(c => c.CardId == CardId)
            .Select(c => c.UserId)
            .Distinct()
            .Count();
        }
    }
}