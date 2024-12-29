namespace bot.Database.Models
{
    public class User
    {
        public required long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Coins { get; set; } = 0;
        public uint Points { get; set; } = 0;
        public int Spins { get; set; } = 10;
        public string Bio { get; set; } = "Olá! Eu estou usando o Arizo.";
        public bool Banned { get; set; } = false;

        // Isso aqui é a propriedade que vai poder fazer navegar na coleção, relação um para muitos
        // (um usuário pode ter várias cartas)
        public ICollection<Collection> Collections { get; set; } = new List<Collection>();
    }
}