using bot.Database.Models;

namespace bot.Database.Repositories
{
    public interface IUser
    {
        void Create(User user);
        User? Read(long Id);
        void Update(User user);
        void Delete(long Id);
    }
}