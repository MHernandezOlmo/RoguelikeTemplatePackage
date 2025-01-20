namespace Statistics.Ports
{
    public interface IStatisticsEventsEmitter
    {
        void OnStatisticChanged(string statisticKey, float previousValue);
    }
}