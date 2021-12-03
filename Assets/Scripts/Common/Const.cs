namespace Common
{
    public static class Const
    {
        public const int FirstScore = 4000;
        public const int MAXScore = 6000;
        public const int Divisor = 200;
        public const int RewardNum = 100;
        public const string ContentScoreInfo = "分数: {0}";
        public const string ContentCoinInfo = "金币: {0}";
        public const string ContentSeasonInfo = "第 {0} 赛季";
        public const string CoinTe = "金币+{0}"; //+是字符串 不是拼接符
    }

    public enum ESegment
    {
        None = 3,
        Gold,
        Platinum, //铂金
        Diamond, //钻石
        King //王者
    }
}