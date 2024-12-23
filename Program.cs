using bot.Database;
using bot.Database.Repositories;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<DatabaseContext>(
            options => options.UseSqlite("Data source=database.db")
        );
        builder.Services.AddScoped<UserRepository>();

        var app = builder.Build();

        string botToken = "7898841697:AAE46Ijd-TIr_WyuzZgIFDsU_K4mxVIWkAA";
        var botService = new BotService(botToken, app.Services);
        botService.Start();
        await Task.Delay(-1);
    }
}
