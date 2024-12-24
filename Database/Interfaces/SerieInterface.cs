using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface ISerieInterface
    {
        List<Serie> GetSeries();
        Serie? GetSerie(int Id);
        Serie CreateSerie(Serie serie);
        Serie? UpdateSerie(int Id);
        void DeleteSerie(int Id);
    }
}