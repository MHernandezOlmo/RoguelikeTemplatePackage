using System.Collections.Generic;
using System.Linq;
using Units.Ports;
using UnityEngine;

namespace Game.Units
{
    
    [CreateAssetMenu(menuName = "Game/Units/Repository", fileName = "UnitStaticDataRepository", order = 0)]
    public class UnitStaticDataRepository : ScriptableObject ,  IUnitStaticDataRepository
    {
        [SerializeField] private List<UnitStaticDataDefinition> unitsDefinitions;

        private Dictionary<string, IUnitStaticData> staticData;


        public void Initialize()
        {
            staticData = unitsDefinitions.ToDictionary(
                x => x.Forename, 
                x => new UnitStaticData(x) as IUnitStaticData);
        }
        
        public IEnumerable<IUnitStaticData> GetElements()
        {
            return staticData.Values;
        }

        public bool TryGet(string key, out IUnitStaticData element)
        {
            return staticData.TryGetValue(key, out  element);
        }

        public IUnitStaticData Get(string key)
        {
            return staticData[key];
        }
    }
}