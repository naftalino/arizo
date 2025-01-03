using bot.Database.Repositories;
using Bot.Commands;
using Bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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

        protected int CanUserUseBot(long userId)
        {
            return new CanUseBot(_UserRepository).CheckCanUse(userId);
        }

        protected abstract Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            if (message.From == null)
            {
                await botClient.SendMessage(message.Chat.Id, "<b>Ocorreu um erro inesperado. Contate: @adorabat.</b>", cancellationToken: cancellationToken, parseMode: ParseMode.Html);
                return;
            }

            switch (CanUserUseBot(message.From.Id))
            {
                case 3:
                    await ExecuteCommandAsync(botClient, message, cancellationToken);
                    break;
                case 2:
                    await botClient.SendMessage(message.Chat.Id, "<b>Você foi banido e não pode usar meus serviços. Retrate-se => @adorabat.</b>", cancellationToken: cancellationToken, parseMode: ParseMode.Html);
                    break;
                case 1:
                    _UserRepository.Create(new Database.Models.User { Id = message.Chat.Id });
                    await botClient.SendMessage(message.Chat.Id, "<b>Você não estava cadastrado. cadastrei você para poder usufruir do game :)</b>", cancellationToken: cancellationToken, parseMode: ParseMode.Html);
                    break;
                default:
                    await botClient.SendMessage(message.Chat.Id, "<b>Ocorreu um erro inesperado. Contate: @adorabat.</b>", cancellationToken: cancellationToken, parseMode: ParseMode.Html);
                    break;
            }
        }
    }
}
