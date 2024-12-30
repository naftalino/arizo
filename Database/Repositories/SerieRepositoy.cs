using bot.Database.Interfaces;
using bot.Database.Models;

namespace bot.Database.Repositories
{
    public enum Genre
    {
        Filme = 1,
        Serie = 2,
        Animacao = 3
    }

    public class SerieRepository : ISerieInterface
    {
        private readonly DatabaseContext _context;
        public SerieRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Serie> GetSeries()
        {
            return _context.Serie.ToList();
        }

        public Serie? GetSerie(int Id)
        {

            var serie = _context.Serie.FirstOrDefault(s => s.Id == Id);
            if (serie == null)
            {
                return null;
            }
            return serie;
        }

        public Serie CreateSerie(Serie serie)
        {
            _context.Serie.Add(serie);
            _context.SaveChanges();
            return serie;
        }

        public Serie? UpdateSerie(int Id)
        {
            var serie = _context.Serie.FirstOrDefault(s => s.Id == Id);
            if (serie == null)
            {
                return null;
            }
            _context.Serie.Update(serie);
            _context.SaveChanges();
            return serie;
        }

        public void DeleteSerie(int Id)
        {
            var serie = _context.Serie.FirstOrDefault(s => s.Id == Id);
            if (serie == null)
            {
                return;
            }
            _context.Serie.Remove(serie);
            _context.SaveChanges();
        }

    }
}