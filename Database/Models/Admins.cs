namespace bot.Database.Models
{
    public class Admins
    {
        public required long UserId { get; set; }
        public long Role { get; set; }
        public bool IsSubOwner { get; set; } = false;
    }
}