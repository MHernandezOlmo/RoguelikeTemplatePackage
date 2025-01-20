using System.Linq;
using Battle.Ports;
using Entities.Ports;

namespace Game.Battle
{
    public class GameBattleResultCalculator : IBattleResultCalculator
    {
        private IBattleSystem battleSystem;
        private IEntitiesSystem entitiesSystem;
        
        public void SetData(IBattleSystem battleSystem, IEntitiesSystem entitiesSystem)
        {
            this.battleSystem = battleSystem;
            this.entitiesSystem = entitiesSystem;
        }
        
        public eBattleResult GetResult(IBattleController battleController)
        {
            if (battleController.HasQuitBattle) return eBattleResult.RUN_AWAY;
            
            var isPlayerAlive = battleSystem.Battle.Model.EntitiesIdsTeam(IBattleSettings.Team.PLAYER).All(unitEntityId =>
                entitiesSystem.TryGetEntity<IEntityController>(unitEntityId, out var entity) && entity.IsAlive);
            var isRivalAlive = battleSystem.Battle.Model.EntitiesIdsTeam(IBattleSettings.Team.RIVAL).All(unitEntityId =>
                entitiesSystem.TryGetEntity<IEntityController>(unitEntityId, out var entity) && entity.IsAlive);
            
            var areBothAlive = isPlayerAlive && isRivalAlive;
            return areBothAlive ? eBattleResult.IN_PROGRESS : (isPlayerAlive ? eBattleResult.PLAYER_WINS : eBattleResult.ENEMY_WINS);
        }
    }
}