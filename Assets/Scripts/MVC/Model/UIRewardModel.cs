using System.Collections.Generic;
using Common;

namespace MVC.Model
{
    public class UIRewardModel
    {
        public readonly List<ItemRewardModel> ItemRewardModels = new List<ItemRewardModel>();

        public void Init()
        {
            InitData(true);
        }

        private void InitData(bool isNewSeason = false)
        {
            const int count = (Const.MAXScore - Const.FirstScore) / Const.Divisor + 1;
            for (var i = 0; i < count; i++)
            {
                var itemRewardModel =
                    new ItemRewardModel(Const.FirstScore + i * Const.Divisor, Const.RewardNum, isNewSeason);
                ItemRewardModels.Add(itemRewardModel);
            }
        }
    }

    public class ItemRewardModel
    {
        public int Score { get; }
        public int RewardNum { get; }
        public bool IsNewSeason { get; private set; }

        public ItemRewardModel(int score, int rewardNum, bool isNewSeason)
        {
            Score = score;
            RewardNum = rewardNum;
            IsNewSeason = isNewSeason;
        }

        public void SetSeason(bool isNewSeason)
        {
            IsNewSeason = isNewSeason;
        }
    }
}