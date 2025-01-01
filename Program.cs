using bot.Database;
using bot.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using bot.Database.Interfaces;
using bot.Operations;

class Program
{
    // espaguete demais, com o tempo eu melhoro isso, prometo.
    static async Task Main(string[] args)
    {
        Env.Load();
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(
            options => options.UseSqlite("Data source=database.db")
        );

        builder.Services.AddControllers();

        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<CollectionRepository>();
        builder.Services.AddScoped<CardRepository>();
        builder.Services.AddScoped<ICardInterface, CardRepository>();

        var app = builder.Build();
        app.MapControllers();

        string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN") ?? throw new InvalidOperationException("BOT_TOKEN environment variable is not set.");
        var botService = new BotService(botToken, app.Services);

        botService.Start();
        //Operations.Run();
        app.Run();

        await Task.Delay(-1);
    }
}
