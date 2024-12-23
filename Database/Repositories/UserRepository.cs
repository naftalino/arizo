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