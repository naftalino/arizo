using bot.Database;
using Microsoft.EntityFrameworkCore;

namespace bot.Operations
{
    public static class Operations
    {
        public static void Run()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlite("Data Source=database.db")
            .Options;

            using var context = new DatabaseContext(options);
            var repo = new AdminRepository(context);
        }
    }
}
