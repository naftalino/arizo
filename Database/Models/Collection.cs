namespace bot.Database.Models
{
    public class Collection
    {
        public required long UserId { get; set; }
        public required int CardId { get; set; }
        public int Quantity { get; set; } = 1;
        public bool Tradeable { get; set; } = true;
        public bool IsFavorite { get; set; } = false;

        public required User User { get; set; }
        public required Card Card { get; set; }
    }
}
