using bot.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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
                var textProfile = $"{info.Id} - {info.Bio}";
                return textProfile;
            }
            else
            {
                return "Nada encontrado.";
            }
        }

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var profile = ShowProfile(message.Chat.Id);
            await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: profile,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html
        );
        }
    }
}
