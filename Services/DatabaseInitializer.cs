using bot.Database;
using Microsoft.EntityFrameworkCore;

namespace bot.Services
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            // context.Database.Migrate();
        }
    }
}