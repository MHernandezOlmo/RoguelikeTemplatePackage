namespace Statistics.Persistence
{
    public class StatisticsModulePersistence : IStatisticsModulePersistence
    {
        private readonly StatisticsSystem system;
        
        public StatisticsModulePersistence(StatisticsSystem system)
        {
            this.system = system;
        }


        public StatisticsPersistentData GeneratePersistentData()
        {
            return system.GetPersistentData();
        }

        public void LoadPersistentData(StatisticsPersistentData data)
        {
            system.LoadPersistentData(data);
        }
    }
}