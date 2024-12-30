using bot.Database.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bot.Bot.Commands
{
    public class SpinCommand : BotCommandBase
    {
        private readonly UserRepository _userRepo;

        public override string Command => "/spin";

        private const string SpinName = "<b>Hora do <i>spin</i>🌀! Selecione uma categoria que você mais preferir.\nObs.: O ticket só será contabilizado como usado após você selecionar alguma categoria.</b>";

        public SpinCommand(UserRepository userRepository)
            : base(userRepository)
        {
            _userRepo = userRepository;
        }

        protected override async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var user = _userRepo.Read(message.Chat.Id);

            if (user?.Spins < 1)
            {
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Você não possui mais spins disponíveis. Considere adquirir mais spins para continuar jogando.",
                    cancellationToken: cancellationToken
                );
                return;
            }

            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: SpinName,
                cancellationToken: cancellationToken,
                parseMode: ParseMode.Html
            );
        }
    }
}
