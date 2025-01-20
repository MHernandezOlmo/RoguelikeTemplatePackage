using System;
using System.Collections.Generic;
using Map.Ports;
using UnityEngine;

namespace Game.Maps
{
    [CreateAssetMenu(menuName = "Game/Maps/MapDefinition", fileName = "MapDefinition", order = 1)]
    public class MapDefinition : ScriptableObject, IMapStaticModel
    {
        [SerializeField] private string forename;
        [SerializeField] private string id;
        [SerializeField] private MapNodeDefinition[] nodes;

        public string MapForename => forename;
        public string MapId => id;
        public IEnumerable<IMapNodeStaticData> Nodes => nodes;
        
        
        [Serializable]
        public class MapNodeDefinition : IMapNodeStaticData
        {
            [SerializeField] private string id;
            [Tooltip("Nodes required to unlock this node. Could use them mix with unlocks")]
            [SerializeField] private string[] required;
            [Tooltip("Nodes this node unlocks. Could use them mix with required")]
            [SerializeField] private string[] unlocks;

            public string Id => id;
            public IEnumerable<string> RequiredNodes => required;
            public IEnumerable<string> UnlockNodes => unlocks;
        }
    }
}