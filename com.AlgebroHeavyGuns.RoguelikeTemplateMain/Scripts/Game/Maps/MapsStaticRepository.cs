using System.Collections.Generic;
using Map.Ports;
using UnityEngine;

namespace Game.Maps
{
    [CreateAssetMenu(menuName = "Game/Maps/Repository", fileName = "MapStaticDataRepository", order = 0)]
    public class MapsStaticRepository : ScriptableObject, IMapsStaticRepository
    {
        [SerializeField] private MapDefinition[] maps;

        public IEnumerable<IMapStaticModel> MapStaticModels => maps;
    }
}