using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Commands
{
    public class HelpCommand : IBotCommand
    {
        public string Command => "/help";
        private string HelpString = "<b>Hm.. Você está um pouco perdido, né?</b>\n\nVocê pode clicar no botão abaixo para ir para a página de explicação dos comandos!";

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var inline = new InlineKeyboardMarkup()
            .AddButton(InlineKeyboardButton.WithUrl("📜 Manual de comandos", "https://google.com/"));
            await botClient.SendMessage(
            chatId: message.Chat.Id,
            text: HelpString,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html,
            replyMarkup: inline
        );
        }
    }
}