using bot.Database.Repositories;
using Bot.Commands;
using Bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Bot.Commands
{
    public abstract class BotCommandBase : IBotCommand
    {
        protected readonly UserRepository _UserRepository;

        protected BotCommandBase(UserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public abstract string Command { get; }

        protected bool CanUserUseBot(long userId)
        {
            return new CanUseBot(_UserRepository).CheckCanUse(userId);
        }

        protected abstract Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (CanUserUseBot(message.From.Id))
            {
                await ExecuteCommandAsync(botClient, message, cancellationToken);
            }
            else
            {
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Você não tem permissão para usar este bot, pois está banido.",
                    cancellationToken: cancellationToken
                );
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
