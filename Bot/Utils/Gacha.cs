using bot.Database.Models;
using bot.Database.Repositories;

namespace bot.Utils
{
    public class Gacha
    {
        private readonly SerieRepository _series;

        public Gacha(SerieRepository series)
        {
            _series = series;
        }

        public Card? Pull(int serieId)
        {
            var serie = _series.GetSerie(serieId);

            if (serie == null || !serie.Cards.Any())
            {
                return null;
            }

            var randomize = serie.Cards
            .OrderBy(c => Guid.NewGuid())
            .FirstOrDefault();

            Console.WriteLine(randomize?.Name);

            return randomize ?? throw new InvalidOperationException("Nenhuma carta disponível para esta série.");
        }
    }
}