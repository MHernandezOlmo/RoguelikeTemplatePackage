using System;
using Entities.Ports;
using Game.Units;
using Units.Ports;
using UnityEngine;

namespace Game.Entities
{
    public class InstantiateUnitEntityService
    {
        private IEntitiesSystem entitiesSystem;
        private IUnitsSystem unitsSystem;

        public void SetData(IEntitiesSystem entitiesSystem, IUnitsSystem unitsSystem)
        {
            this.entitiesSystem = entitiesSystem;
            this.unitsSystem = unitsSystem;
        }

        public T Instantiate<T>(string unitId) where T : IEntityController
        {
            return Instantiate<T>(unitId.GetHashCode());
        }
        
        public T Instantiate<T>(int unitId) where T : IEntityController
        {
            if (!unitsSystem.TryGetUnit(unitId, out var unitModel))
                throw new ArgumentException("Not found unit with id=" + unitId);
            var position = Vector3.zero;
            var rotation = Quaternion.identity;
            var staticData = UnitStaticToEntityStaticConverter.ConvertToEntityStatic<T>(unitModel);
            var entityController = entitiesSystem.CreateEntity<T>(position, rotation, staticData);
            return entityController;
        }
    }
}