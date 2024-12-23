namespace bot.Database.Models
{
    public class History
    {
        public int Id { get; set; }
        public required string Item { get; set; }
        public DateTime Date { get; set; }
    }
}