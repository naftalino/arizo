using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IRankingCapitivityInterface
    {
        void AddRankCapitivity(RankingCaptivity rankCapitivity);
        void UpdateRankCapitivity(RankingCaptivity rankCapitivity);
        RankingCaptivity GetRankCapitivity(int id);
    }
}