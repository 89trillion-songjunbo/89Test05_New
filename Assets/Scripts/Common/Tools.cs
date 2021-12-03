namespace Common
{
    public static class CommonTool
    {
        public static string GetSegment(int selfScore)
        {
            var tmpSeg = "";
            var per = selfScore / 1000;
            var segment = per <= 3 ? ESegment.None : (ESegment) per;
            switch (segment)
            {
                case ESegment.None:
                    tmpSeg = "段位: 无";
                    break;
                case ESegment.Gold:
                    tmpSeg = "段位: 黄金";
                    break;
                case ESegment.Platinum:
                    tmpSeg = "段位: 铂金";
                    break;
                case ESegment.Diamond:
                    tmpSeg = "段位: 砖石";
                    break;
                case ESegment.King:
                    tmpSeg = "段位: 王者";
                    break;
                default:
                    tmpSeg = "段位: 大帝";
                    break;
            }

            return tmpSeg;
        }
    }
}