using System;
using Core.Install.Ports;
using Core.Save.Ports;
using Map.Persistence;
using Statistics.Persistence;
using User.Persistence;

namespace Game.Save.Services
{
    public class GamePersistentRepository : IPersistentRepository<PersistentData>
    {
        private IStatisticsModulePersistence statisticsModulePersistence;
        private IMapProgressModulePersistence mapModulePersistence;
        private IUserModulePersistence userModulePersistence;

        public void Install(IReferencesRepository referencesRepository)
        {
            statisticsModulePersistence = referencesRepository.GetReference<IStatisticsModulePersistence>();
            mapModulePersistence = referencesRepository.GetReference<IMapProgressModulePersistence>();
            userModulePersistence = referencesRepository.GetReference<IUserModulePersistence>();
        }
        
        public PersistentData GetPersistentData()
        {
            var data = new PersistentData
            {
                systemTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                StatisticsPersistentData = statisticsModulePersistence.GeneratePersistentData(),
                MapsProgressPersistentData = mapModulePersistence.GeneratePersistentData(),
                UserPersistentData = userModulePersistence.GeneratePersistentData(),
            };
            return data;
        }

        public void SetLoadedData(PersistentData data)
        {
            statisticsModulePersistence.LoadPersistentData(data.StatisticsPersistentData);
            mapModulePersistence.LoadPersistentData(data.MapsProgressPersistentData);
            userModulePersistence.LoadPersistentData(data.UserPersistentData);
        }

        public void ResetData()
        {
            mapModulePersistence.ResetPersistentData();
            userModulePersistence.ResetPersistentData();
        }
    }
}