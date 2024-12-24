namespace bot.Database.Models
{
    public class Collection
    {
        public required long UserId { get; set; }
        public required int CardId { get; set; }
        public int Quantity { get; set; }
        public bool Tradeable { get; set; }
        public bool IsFavorite { get; set; }
        public required User User { get; set; }
        public required Card Card { get; set; }
    }
}
