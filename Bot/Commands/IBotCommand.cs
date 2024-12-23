using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands{
    public interface IBotCommand
    {
    string Command { get; }
    Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
    }
}
