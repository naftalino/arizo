namespace bot.Database.Models
{
    public class Subserie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImageURL { get; set; }
        public int SerieId { get; set; }
    }
}