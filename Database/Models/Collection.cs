namespace bot.Database.Models
{
    public class Collection
    {
        public required long UserId { get; set; }
        public required int CardId { get; set; }
        public required int Quantity { get; set; } = 1;
        public required bool Tradeable { get; set; } = true;
        public required bool IsFavorite { get; set; }
        public required User User { get; set; }
        public required Card Card { get; set; }
    }
}
