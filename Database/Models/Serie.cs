namespace bot.Database.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public required string Genre { get; set; }
        public List<Card> Cards { get; set; } = new();
        public bool IsFromSubSerie { get; set; } = false;
        public int SubSerieId { get; set; } = 0; // 0 means it's not a subserie
    }
}