using bot.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace bot.Bot.Commands
{
    public class SpinCommand : BotCommandBase
    {
        private readonly UserRepository _userRepo;

        public override string Command => "/spin";

        private const string SpinName = "<b>Hora do <i>spin</i>🌀! Selecione uma categoria abaixo para sortear uma série.\nObs.: O ticket só será contabilizado como usado após você selecionar alguma categoria.</b>";

        public SpinCommand(UserRepository userRepository)
            : base(userRepository)
        {
            _userRepo = userRepository;
        }

        protected override async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            // var inline = new InlineKeyboardMarkup()
            //     .AddButton(InlineKeyboardButton.WithCallbackData("Configurar perfil", "configurar_meu_perfil"));

            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: SpinName,
                cancellationToken: cancellationToken,
                parseMode: ParseMode.Html
            // replyMarkup: inline
            );
        }
    }
}
