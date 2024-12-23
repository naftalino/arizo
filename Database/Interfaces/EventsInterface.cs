using bot.Database.Models;

namespace bot.Database.Interfaces
{
public interface IEventsInterface
{
    bool CreateEvent(string name, string description, string imageUrl, DateTime startDate, DateTime endDate, int serieId);
    bool DeleteEvent(int EventId);
    bool UpdateEvent(int EventId);
    Events GetEvent(int EventId);
    List<Events> GetEventsByStartDate(DateTime StartDate);
    List<Events> GetAllEvents();
}
}
