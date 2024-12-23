using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface ISerieInterface
    {
        Task<List<Serie>> GetSeries();
        Task<Serie> GetSerie(int Id);
        Task<Serie> CreateSerie(Serie serie);
        Task<Serie> UpdateSerie(int Id, Serie serie);
        Task<Serie> DeleteSerie(int Id);
    }
}