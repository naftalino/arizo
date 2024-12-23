using bot.Database.Repositories;
using Bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Commands
{
    public class StartCommand : IBotCommand
    {
        private readonly UserRepository _userRepo;
        public string Command => "/start";
        private string IsNew = "<b>Olá! Meu nome é <i>Arizo, a lontra.</i> Prazer conhecer você!\nO que deseja fazer hoje?</b>";
        //private readonly string Description = "Inicializa o bot";

        public StartCommand(UserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            long userId;
            var can = new CanUseBot(_userRepo);

            if (message.Chat.Type != ChatType.Private)
            {
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Esse comando só pode ser usado em conversas privadas. Por favor, me chame em privado.",
                    cancellationToken: cancellationToken
                );
                return;
            }

            if (!can.CheckCanUse(message.Chat.Id))
            {
                var inline2 = new InlineKeyboardMarkup()
                .AddButton(InlineKeyboardButton.WithUrl("Dev", "https://t.me/adorabat"));

                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Você não pode usar o bot pois foi banido. Por favor, entre em contato com o desenvolvedor.",
                    cancellationToken: cancellationToken,
                    parseMode: ParseMode.Html,
                    replyMarkup: inline2
                );
                return;
            }

            var user = _userRepo.Read(message.Chat.Id);
            if (user == null)
            {
                _userRepo.Create(new bot.Database.Models.User { Id = message.Chat.Id });
                userId = message.Chat.Id;
            }
            else
            {
                userId = user.Id;
            }

            var inline = new InlineKeyboardMarkup()
            .AddButton(InlineKeyboardButton.WithUrl("Canal de atualizações", "https://t.me/arizocard"))
            .AddNewRow()
            .AddButton(InlineKeyboardButton.WithUrl("Dev", "https://t.me/adorabat"))
            .AddButton(InlineKeyboardButton.WithCopyText("Copiar seu ID", $"{userId}"));

            await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: IsNew,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html,
            replyMarkup: inline
        );
        }
    }
}
