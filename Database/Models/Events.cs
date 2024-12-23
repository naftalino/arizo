namespace bot.Database.Models;

public class Events
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public required string ImageUrl { get; set; }
    public required string TypePrize { get; set; }
    public required List<string> Prizes { get; set; }
    public TimeSpan Duration => EndDate - StartDate;

}
