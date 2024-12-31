using bot.Database.Repositories;

namespace bot.Database.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string ImageURL { get; set; } = "https://placehold.co/600x400";
        public DateTime ReleaseDate { get; set; }
        public required Genre Genre { get; set; } // 1 = Filmes, 2 = Séries, 3 = Animações
        public List<Card> Cards { get; set; } = new();
        public bool IsFromSubSerie { get; set; } = false;
        public int SubSerieId { get; set; } = 0; // 0 quer dizer que NÃO é uma subserie
    }
}
