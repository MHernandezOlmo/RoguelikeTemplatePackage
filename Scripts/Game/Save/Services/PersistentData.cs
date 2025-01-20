using System;
using Map.Persistence;
using Statistics.Persistence;
using User.Persistence;

namespace Game.Save.Services
{
    [Serializable]
    public class PersistentData
    {
        public long systemTimestamp;
        public StatisticsPersistentData StatisticsPersistentData = new();
        public MapsProgressPersistentData MapsProgressPersistentData= new();
        public UserPersistentData UserPersistentData= new();
    }
}