using System;
using System.Collections.Generic;
using Units.Ports;

namespace Game.Entities
{
    public class EntityAttributesFactory
    {
        private IUnitsSystem unitsSystem;

        public void SetData(IUnitsSystem unitsSystem)
        {
            this.unitsSystem = unitsSystem;
        }

        public Tuple<Dictionary<int, float>,Dictionary<int, float>>  GenerateAttributesFromEntityData(GenericEntityController.StaticModel staticModel)
        {
            var currentAttributes = new Dictionary<int, float>();
            var maxAttributes = new Dictionary<int, float>();
            if (!unitsSystem.TryGetUnit(staticModel.TemplateId, out var templateUnitModel)) return new(currentAttributes, maxAttributes);
            
            var templateAttributes =
                templateUnitModel.StaticData.AttributesAtLevel(staticModel.Level);
            foreach (var staticAttribute in templateAttributes.Attributes)
            {
                currentAttributes.Add(staticAttribute.Key, staticAttribute.Value);
                maxAttributes.Add(staticAttribute.Key, staticAttribute.Value);
            }
            return new(currentAttributes, maxAttributes);
        }
    }
}