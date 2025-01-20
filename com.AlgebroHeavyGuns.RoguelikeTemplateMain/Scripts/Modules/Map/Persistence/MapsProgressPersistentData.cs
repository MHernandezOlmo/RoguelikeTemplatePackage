using System;
using System.Collections.Generic;
using Map;

namespace Map.Persistence
{
    [Serializable]
    public class MapsProgressPersistentData
    {
        public List<MapProgressPersistentData> mapsData = new ();
    }
    
    public class MapProgressModulePersistence : IMapProgressModulePersistence
    {
        private readonly MapSystem system;
        
        public MapProgressModulePersistence(MapSystem system)
        {
            this.system = system;
        }
        
        public void LoadPersistentData(MapsProgressPersistentData data)
        {
            system.LoadPersistentData(data);
        }

        public void ResetPersistentData()
        {
            system.ResetData();
        }

        public MapsProgressPersistentData GeneratePersistentData()
        {
            return system.GetPersistentData();
        }
    }
}