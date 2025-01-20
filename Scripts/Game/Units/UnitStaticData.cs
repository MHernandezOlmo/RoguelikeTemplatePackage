using System.Collections.Generic;
using System.Linq;
using Units.Ports;
using UnityEngine;

namespace Game.Units
{
    public class UnitStaticData : IUnitStaticData
    {
        public int Id { get; }
        public string BasicImageKey { get; }
        public string Forename { get; }
        public IEnumerable<IUnitLevelingData> AttributesAtAllLevels => levelingAttributes;
        public IUnitLevelingData AttributesAtLevel(int level) => levelingAttributes[Mathf.Clamp(level, 0, MaxLevel)];
        public int MaxLevel => levelingAttributes.Count;
        public string ViewId { get; }
        
        private readonly List<UnitLevelingData> levelingAttributes;

        public UnitStaticData(UnitStaticDataDefinition unitStaticDataDefinition)
        {
            Id = unitStaticDataDefinition.Forename.GetHashCode();
            ViewId = unitStaticDataDefinition.EntityViewId;
            Forename = unitStaticDataDefinition.Forename;
            BasicImageKey = unitStaticDataDefinition.ImageKey;
            levelingAttributes = unitStaticDataDefinition.LevelingAttributes.
                Select(definition => new UnitLevelingData(definition))
                .ToList();
        }
    }
}