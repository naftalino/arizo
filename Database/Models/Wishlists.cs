namespace bot.Database.Models
{
    public class Wishlists
    {
        public int Id { get; set; }
        public required string Card { get; set; }
        public required bool IsForCapitivity { get; set; }
    }
}