using System.Collections.Generic;
using System.Linq;
using Map.Ports;
using Map.Persistence;
using UnityEngine;


namespace Map
{
    public class MapSystem : IMapSystem
    {
        private Dictionary<string, MapController> maps;

        private IMapsStaticRepository mapsStaticRepository;

        public void SetData(IMapsStaticRepository mapsStaticRepository)
        {
            this.mapsStaticRepository = mapsStaticRepository;
        }
        
        public void Initialize()
        {
            maps = mapsStaticRepository.MapStaticModels.ToDictionary(x => x.MapId,
                x => new MapController(x));
        }

        public void Dispose()
        {
            maps.Clear();
            maps = null;
        }
        
        public bool TryGetMap(string mapId, out IMapController mapController)
        {
            mapController = default;
            if(!maps.TryGetValue(mapId, out var controller)) return false;
            mapController = controller;
            return true;
        }

        public void LoadPersistentData(MapsProgressPersistentData data)
        {
            foreach (var mapProgressData in data.mapsData)
            {
                if (!maps.TryGetValue(mapProgressData.mapID, out var controller))
                {
                    Debug.LogError(
                        $"Expected map {mapProgressData.mapID} from saved data.  Is missing on static data repository?");
                    continue;
                }

                foreach (var nodeId in mapProgressData.completedNodeIds)
                {
                    controller.SetAsCompleted(nodeId);
                }

                controller.RefreshAvailability();
            }
        }
        
        public void ResetData()
        {
            foreach (var (key, map) in maps)
            {
                map.ResetProgress();
                map.RefreshAvailability();
            }
        }

        public MapsProgressPersistentData GetPersistentData()
        {
            return new MapsProgressPersistentData()
            {
                mapsData = maps.Values
                    .Select(map => new MapProgressPersistentData()
                {
                    mapID = map.MapId,
                    completedNodeIds = map.Nodes
                        .Where(node => node.IsCompleted)
                        .Select(node => node.StaticData.Id)
                        .ToList(),
                }).ToList()
            };
        }
    }
}
