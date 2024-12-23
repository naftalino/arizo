namespace bot.Database.Models
{
    public class Rewards
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required List<string> Prize { get; set; }
    }
}