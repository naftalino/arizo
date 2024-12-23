using bot.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Commands
{
    public class ProfileCommand : IBotCommand
    {
        public string Command => "/profile";
        private readonly UserRepository _UserRepository;

        public ProfileCommand(UserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public string ShowProfile(long userID)
        {
            var info = _UserRepository.Read(userID);
            if (info != null)
            {
                var textProfile = @$"
👤 <i><b>Seu lindo perfil:</b></i>

🆔: <code>{info.Id}</code>
💬: <code>{info.Bio}</code>
🃏: <code>{info.CardQuantity}</code>
🪙: <code>{info.Coins}</code>
                ";
                return textProfile;
            }
            else
            {
                return "Eu te conheço? Kkkkkkk";
            }
        }

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var profile = ShowProfile(message.Chat.Id);
            var inline = new InlineKeyboardMarkup()
            .AddButton(InlineKeyboardButton.WithCopyText("Copiar perfil", profile));

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
