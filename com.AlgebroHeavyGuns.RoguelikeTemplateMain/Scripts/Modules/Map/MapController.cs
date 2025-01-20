using System.Collections.Generic;
using System.Linq;
using Map.Ports;
using UnityEngine;

namespace Map
{
    public class MapController : IMapController
    {
        public string MapForename => mapModel.MapForename;
        public string MapId => mapModel.MapId;
        public IEnumerable<MapNodeModel> Nodes => nodes.Values;
        public bool IsCompleted => nodes.Values.All(x => x.IsCompleted);

        private IMapStaticModel mapModel;
        private readonly Dictionary<string, MapNodeModel> nodes;

        public MapController(IMapStaticModel model)
        {
            mapModel = model;
            nodes = model.Nodes.ToDictionary(x => x.Id,
                x => new MapNodeModel(x));
            RefreshAvailability();
        }


        public void SetAsCompleted(string nodeId)
        {
            if(!nodes.TryGetValue(nodeId, out var nodeModel))
            {
                Debug.LogError($"Not found node {nodeId} on {mapModel.MapId} map.  Failed set node as completed.");
                return;
            }
            nodeModel.IsCompleted = true;
        }
        
        public void RefreshAvailability()
        {
            foreach (var nodeModel in nodes.Values)
            {
                nodeModel.IsAvailable = CalculateNodeAvailable(nodeModel);
            }
        }

        private bool CalculateNodeAvailable(MapNodeModel nodeModel)
        {
            var requiredNodeCompleted = nodeModel.StaticData.RequiredNodes.All(node => nodes[node].IsCompleted);
            var requiredUnlockNodes =
                nodes.Values.Where(node => node.StaticData.UnlockNodes.Contains(nodeModel.StaticData.Id)).ToArray();
            var isLocked = requiredUnlockNodes.Length > 0 && requiredUnlockNodes.All(node => !node.IsCompleted);
            return requiredNodeCompleted && !isLocked;
        }

        public void ResetProgress()
        {
            foreach (var mapNodeModel in nodes.Values)
            {
                mapNodeModel.IsCompleted = false;
            }
        }
    }
}