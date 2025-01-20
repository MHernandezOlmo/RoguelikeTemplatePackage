using System.Collections.Generic;
using System.Linq;
using Items.Ports;
using UnityEngine;

namespace Game.Items
{
    [CreateAssetMenu(menuName = "Game/Items/Repository", fileName = "ItemStaticDataRepository", order = 0)]
    public class ItemStaticDataRepository : ScriptableObject ,  IItemStaticDataRepository
    {
        [SerializeField] private List<ItemStaticDataDefinition> itemsDefinitions;

        private Dictionary<string, IItemStaticData> staticData;
        
        public void Initialize()
        {
            staticData = itemsDefinitions.ToDictionary(
                x => x.Forename, 
                x => new ItemStaticData(x) as IItemStaticData);
        }
        
        public IEnumerable<IItemStaticData> GetElements()
        {
            return staticData.Values;
        }

        public bool TryGet(string key, out IItemStaticData element)
        {
            return staticData.TryGetValue(key, out  element);
        }

        public IItemStaticData Get(string key)
        {
            return staticData[key];
        }
    }
}