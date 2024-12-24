using bot.Database.Repositories;
using Bot.Commands;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
class BotService
{
    private readonly TelegramBotClient _bot;
    private readonly List<IBotCommand> _commands;
    private readonly IServiceProvider _services;

    public BotService(string token, IServiceProvider services)
    {
        _services = services;

        _bot = new TelegramBotClient(token);

        _commands = new List<IBotCommand>
        {
            new StartCommand(_services.GetRequiredService<UserRepository>()),
            new HelpCommand(),
            new ProfileCommand(_services.GetRequiredService<UserRepository>()),
        };
    }

    public void Start()
    {
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message, UpdateType.CallbackQuery}
        };

        _bot.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: default
        );
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("Bot Inicializado.");
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message && update.Message?.Text != null)
        {
            var message = update.Message;
            var command = _commands.FirstOrDefault(c => message.Text.StartsWith(c.Command));

            if (command != null)
            {
                await command.ExecuteAsync(botClient, message, cancellationToken);
            }
            else
            {
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Comando não reconhecido. Use /help para ver os comandos disponíveis.",
                    cancellationToken: cancellationToken
                );
            }
        }
    }

    private async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Callback recebido: {callbackQuery.Data}");
        await _bot.AnswerCallbackQuery(
            callbackQueryId: callbackQuery.Id,
            text: "Callback recebido!",
            showAlert: true,
            cancellationToken: cancellationToken
        );
    }
    private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Erro: {exception.Message}");
        return Task.CompletedTask;
    }
}
