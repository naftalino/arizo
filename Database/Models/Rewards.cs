namespace bot.Database.Models
{
    public class Rewards
    {
        public required int Id { get; set; }
        public required string Code { get; set; }
        public required List<string> Prize { get; set; }
        public required DateTime ExpiryDate { get; set; }
    }
}