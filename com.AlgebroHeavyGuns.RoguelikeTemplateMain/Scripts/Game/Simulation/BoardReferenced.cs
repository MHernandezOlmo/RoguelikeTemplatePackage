using System.Collections.Generic;
using System.Linq;
using Battle.Ports;
using Entities.Ports;
using Simulation.Ports;

namespace Game.Simulation
{
    public class BoardReferenced : IBoardState
    {
        private IEntitiesSystem entitiesSystem;
        private IBattleSystem battleSystem;

        public IEnumerable<IUnitEntityState> UnitsStates => GenerateUnitsStatesFromEntities();

        public void SetData(IEntitiesSystem entitiesSystem, IBattleSystem battleSystem)
        {
            this.entitiesSystem = entitiesSystem;
            this.battleSystem = battleSystem;
        }

        public bool TryGetUnitWithId(int id, out IUnitEntityState unitState)
        {
            unitState = null;
            if(!entitiesSystem.TryGetEntity<IEntityController>(id, out var entityController)) return false;
            unitState = new GameSimulatedUnitEntity(entityController);
            return true;
        }

        public void ApplyCurrentHealthVariationTo(ApplicationParams.HealthVariationParams applicationParams)
        {
            entitiesSystem.TryGetEntity<IEntityController>(applicationParams.UnitTargetId, out var targetUnit);
            targetUnit.ApplyHealthVariation(applicationParams.HealthVariation);
        }

        private IEnumerable<IUnitEntityState> GenerateUnitsStatesFromEntities()
        {
            var allies = battleSystem.Battle.Model.EntitiesIdsTeam(IBattleSettings.Team.PLAYER).Select(entityId =>
            {
                entitiesSystem.TryGetEntity<IEntityController>(entityId, out var entityController);
                return new GameSimulatedUnitEntity(entityController);
            });
            var rivals = battleSystem.Battle.Model.EntitiesIdsTeam(IBattleSettings.Team.RIVAL).Select(entityId =>
            {
                entitiesSystem.TryGetEntity<IEntityController>(entityId, out var entityController);
                return new GameSimulatedUnitEntity(entityController);
            });
            return allies.Concat(rivals);
        }
    }
}