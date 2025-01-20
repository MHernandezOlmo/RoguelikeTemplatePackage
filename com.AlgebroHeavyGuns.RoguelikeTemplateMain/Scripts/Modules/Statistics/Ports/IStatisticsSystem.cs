namespace Statistics.Ports
{
    public interface IStatisticsSystem
    {
        void AddStatistic(string statisticKey, float value);
        void SetStatistic(string statisticKey, float value);
        bool HasStatistic(string statisticKey);
        float GetStatisticFloat(string statisticKey);
        int GetStatisticInt(string statisticKey);
    }
}