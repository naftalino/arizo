using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IAdmin
    {
        void CreateAdmin(long userId);
        void DeleteAdmin(long userId);
        void UpdateAdmin(long userId);
        Admins GetAdmin(long userId);
        List<Admins> GetAdmins();
    }
}