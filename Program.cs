using bot.Database;
using bot.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using bot.Utils;
class Program
{
    // espaguete demais, com o tempo eu melhoro isso, prometo.
    static async Task Main(string[] args)
    {
        Env.Load();
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<DatabaseContext>(
            options => options.UseSqlite("Data source=database.db")
        );

        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<CollectionRepository>();
        //builder.Services.AddScoped<Gacha>();

        var app = builder.Build();

        string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN") ?? throw new InvalidOperationException("BOT_TOKEN environment variable is not set.");
        var botService = new BotService(botToken, app.Services);

        botService.Start();

        await Task.Delay(-1);
    }
}
