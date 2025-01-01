using bot.Database;
using bot.Database.Models;
using bot.Database.Repositories;
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
            var repo = new CollectionRepository(context);
            repo.InsertCardOnCollection(new Collection { CardId = 1, UserId = 7754973240 });
            System.Console.WriteLine("deu tudo certo");
        }
    }
}
