using bot.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Commands
{
    //        var gacha = new Gacha().Pull(1);

    public class ProfileCommand : IBotCommand
    {
        public string Command => "/profile";
        private readonly UserRepository _UserRepository;

        public ProfileCommand(UserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var profile = _UserRepository.Profile(message.Chat.Id);

            var inline = new InlineKeyboardMarkup()
            .AddButton(InlineKeyboardButton.WithCallbackData("Configurar perfil", "configurar_meu_perfil"));

            await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: profile,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html,
            replyMarkup: inline
        );
        }
    }
}
