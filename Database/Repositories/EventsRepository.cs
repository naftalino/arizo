using bot.Database.Interfaces;
using bot.Database.Models;

namespace bot.Database.Repositories
{
    public class EventsRepository : IEventsInterface
    {
        private readonly DatabaseContext _context;

        public EventsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool CreateEvent(Events events)
        {
            _context.Events.Add(events);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteEvent(int EventId)
        {
            var events = _context.Events.Find(EventId);
            if (events == null)
            {
                return true;
            }
            _context.Events.Remove(events);
            _context.SaveChanges();
            return true;
        }

        public Events? GetEvent(int id)
        {
            var events = _context.Events.Find(id);
            if (events == null)
            {
                return null;
            }
            return events;
        }

        public bool UpdateEvent(int Id)
        {
            var events = _context.Events.Find(Id);
            if (events == null)
            {
                return false;
            }
            _context.Events.Update(events);
            _context.SaveChanges();
            return true;
        }

        public List<Events> GetAllEvents()
        {
            return _context.Events.ToList();
        }

    }
}