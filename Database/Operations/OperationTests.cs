using bot.Database;
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
            var cartastem = new CardRepository(context);

            var cardsteem = cartastem.HowManyUsersHaveCard(1);
            Console.WriteLine(cardsteem);

            var series = repo.HowManyCardsUserHas(1); // Assuming 1 is the card ID
            Console.WriteLine(series);
        }
    }
}
