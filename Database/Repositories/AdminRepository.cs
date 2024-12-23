using bot.Database;
using bot.Database.Interfaces;
using bot.Database.Models;

public class AdminRepository : IAdmin
{
    private readonly DatabaseContext _context;

    public AdminRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void CreateAdmin(long userId)
    {
        _context.Add(new Admins { Id = userId });
        _context.SaveChanges();
    }

    public void DeleteAdmin(long userId)
    {
        var admin = _context.Admins.FirstOrDefault(a => a.Id == userId);
        if (admin != null)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }
    }

    public void UpdateAdmin(long userId)
    {
        var admin = _context.Admins.FirstOrDefault(a => a.Id == userId);
        if (admin != null)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
    }

    public Admins GetAdmin(long userId)
    {
        return _context.Admins.FirstOrDefault(a => a.Id == userId)!;
    }

    public List<Admins> GetAdmins()
    {
        return _context.Admins.ToList();
    }
}