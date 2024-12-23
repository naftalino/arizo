namespace bot.Database.Models
{
    public class Shop
    {
        public required int Card { get; set; }
        public required string Price { get; set; }
        public int StockQuantity { get; set; }
    }
}