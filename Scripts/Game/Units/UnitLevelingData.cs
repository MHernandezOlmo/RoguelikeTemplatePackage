using System.Collections.Generic;
using Game.Entities;
using Units.Ports;

namespace Game.Units
{
    public class UnitLevelingData : IUnitLevelingData
    {
        private readonly Dictionary<int, float> attributes;

        public bool TryGetAttribute(int attributeKey, out float value) => attributes.TryGetValue(attributeKey, out value);
        public IEnumerable<KeyValuePair<int, float>> Attributes => attributes;

        public UnitLevelingData(UnitLevelAttributesDefinition levelAttributesDefinition)
        {
            attributes = new Dictionary<int, float>()
            {
                { EntityAttributesConstants.HEALTH, levelAttributesDefinition.Health },
                { EntityAttributesConstants.STRENGTH, levelAttributesDefinition.Strength },
                { EntityAttributesConstants.SPEED, levelAttributesDefinition.Speed },
            };
        }
    }
}