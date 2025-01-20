namespace Statistics.Persistence
{
    public interface IStatisticsModulePersistence
    {
        StatisticsPersistentData GeneratePersistentData();
        void LoadPersistentData(StatisticsPersistentData data);
    }
    
}
