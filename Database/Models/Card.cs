namespace bot.Database.Models
{
    public class Card
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; } = "https://placehold.co/400x600/png";
        public required string Rarity { get; set; } = "Common";
        public bool CanBeSold { get; set; } = true;
        public int Price { get; set; } = new Random().Next(1, 100);
        public bool IsLimitedEdition { get; set; } = false;
        public int Popularity { get; set; } = 0;
        public required int SerieId { get; set; }
        public Serie Serie { get; set; }
        public List<Card> Cards { get; set; } = new();
        public List<Collection> Collections { get; set; } = new();
    }
}