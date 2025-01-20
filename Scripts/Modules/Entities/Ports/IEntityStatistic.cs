namespace Entities.Ports
{
    public interface IEntityStatistic
    {
        void AddStatistic(string statisticKey, float value);
        void SetStatistic(string statisticKey, float value);
        float GetStatisticFloat(string statisticKey);
        int GetStatisticInt(string statisticKey);
    }
}