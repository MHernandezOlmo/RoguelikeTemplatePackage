using System.Collections.Generic;
using System.Linq;
using Items.Ports;
using UnityEngine;

namespace Game.Items
{
    public class ItemStaticData : IItemStaticData
    {
        public int Id { get; }
        public eItemRarity Rarity { get; set; }
        public string ItemImageKey { get; }
        public string Forename { get; }
        public IEnumerable<IItemLevelingData> AttributesAtAllLevels => levelingAttributes;
        public IItemLevelingData AttributesAtLevel(int level) => levelingAttributes[Mathf.Clamp(level, 0, MaxLevel)];
        public int MaxLevel => levelingAttributes.Count;
        public IEnumerable<KeyValuePair<int, string>> SkillTriggers { get; }

        private readonly List<ItemLevelingData> levelingAttributes = new ();
        
        public ItemStaticData(ItemStaticDataDefinition unitStaticDataDefinition)
        {
            Id = unitStaticDataDefinition.Forename.GetHashCode();
            ItemImageKey = unitStaticDataDefinition.ImageKey;
            Forename = unitStaticDataDefinition.Forename;
            Rarity = unitStaticDataDefinition.Rarity;
            //levelingAttributes = unitStaticDataDefinition.LevelingAttributes.Select(definition => new ItemLevelingData(definition)).ToList();
            SkillTriggers = unitStaticDataDefinition.SkillTriggers.Select(definition => new KeyValuePair<int, string>((int)definition.TriggerKey, definition.SkillId));
        }
    }
}