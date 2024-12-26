using bot.Database.Models;

namespace bot.Database.Repositories
{
    public class UserRepository : IUser
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            var user = _context.User.FirstOrDefault(p => p.Id == Id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }

        public User? Read(long Id)
        {
            return _context.User.FirstOrDefault(p => p.Id == Id);
        }

        public string Profile(long Id)
        {
            var getCardsCount = new CollectionRepository(_context).HowManyCardsUserHas(Id);
            var info = Read(Id);
            if (info != null)
            {
                var textProfile = @$"
👤 <i><b>Seu lindo perfil:</b></i>

🆔 <b>ID</b>: <code>{info.Id}</code>
💬 <b>Bio</b>: <code>{info.Bio}</code>
🃏 <b>Cards Totais</b>: <code>{getCardsCount}</code>
🪙 <b>Coins</b>: <code>{info.Coins}</code>
✴️ <b>Points</b>: <code>{info.Points}</code>
🎰 <b>Fichas</b>: <code>{info.Spins}</code>
                ";
                return textProfile;
            }
            else
            {
                return "Usuário, você não está cadastrado. Considere o comando /start para que eu possa te adicionar!";
            }
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }
    }
}