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
            var repo = new SerieRepository(context);
            var serieCreated = repo.CreateSerie(new Serie { Genre = Genre.Serie, Name = "Breaking Bad" });
            Console.WriteLine(serieCreated.Id);
            repo.GetSerie(serieCreated.Id);
        }
    }
}
