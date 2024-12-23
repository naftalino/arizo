using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IRewardsInterface
    {
        void CreateReward(Rewards reward);
        void UpdateReward(Rewards reward);
        Rewards GetReward(int id);
        DateTime ValidateReward(int id);
        void DeleteReward(int id);
        void InsertRewardIntoUser(int userId, int rewardId);
    }
}