using System;
using System.Collections.Generic;
using System.Linq;
using Game.Battle;
using Items.Ports;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Items
{
    [CreateAssetMenu(menuName = "Game/Items/Definition", fileName = "ItemStaticDataDefinition", order = 0)]
    public class ItemStaticDataDefinition : ScriptableObject
    {
        [SerializeField] private string unitForename;
        [SerializeField] private eItemRarity rarity;
        [SerializeField] private string imageKey;
        //[SerializeField] private List<ItemLevelAttributesDefinition> levelingAttributes;
        [SerializeField] private List<SkillTriggerDefinition> skillTriggers;

        //public IEnumerable<ItemLevelAttributesDefinition> LevelingAttributes => levelingAttributes;
        public string Forename => unitForename;
        public string ImageKey => imageKey;
        public eItemRarity Rarity => rarity;
        public IEnumerable<SkillTriggerDefinition> SkillTriggers => skillTriggers;
    }

    [Serializable]
    public class SkillTriggerDefinition
    {
        public eBattleTrigger TriggerKey;
        public string SkillId;
    }
}