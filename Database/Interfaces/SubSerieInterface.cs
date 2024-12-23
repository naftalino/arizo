using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface ISubSerieInterface
    {
        Task<List<Subserie>> GetSubSeries();
        Task<Subserie> GetSubSerie(int Id);
        Task<Subserie> GetSubSerieByName(string Name);
        Task<Subserie> CreateSubSerie(Subserie subSerie);
        Task<Subserie> UpdateSubSerie(int Id, Subserie subSerie);
        Task<Subserie> DeleteSubSerie(int Id);
    }
}
