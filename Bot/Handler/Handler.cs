using bot.Database.Repositories;

/* This class is used to check if the user can use the bot.
For example, if the user is banned, the bot will not respond to the user.
*/

namespace Bot.Handler
{
    public class CanUseBot
    {
        private readonly UserRepository _userRepo;
        public CanUseBot(UserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public int CheckCanUse(long userId)
        {
            var user = _userRepo.Read(userId);

            if (user == null)
            {
                return 1;
            }

            if (user.Banned)
            {
                return 2;
            }
            return 3;
        }
    }
}
