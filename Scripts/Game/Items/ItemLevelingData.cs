using System.Collections.Generic;
using System.Linq;
using Items.Ports;

namespace Game.Items
{
    public class ItemLevelingData : IItemLevelingData
    {
        private readonly Dictionary<string, float> bonuses;

        public bool TryGetBonus(string attributeKey, out float value) => bonuses.TryGetValue(attributeKey, out value);
        public IEnumerable<KeyValuePair<string, float>> GetBonuses() => bonuses;

        public ItemLevelingData(ItemLevelAttributesDefinition levelAttributesDefinition)
        {
            bonuses = levelAttributesDefinition.Bonus.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}