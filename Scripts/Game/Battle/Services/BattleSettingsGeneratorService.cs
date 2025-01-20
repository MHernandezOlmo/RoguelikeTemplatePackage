using System.Collections.Generic;
using Battle.Ports;
using Battle.Services;
using Game.Entities;

namespace Game.Battle.Services
{
    public class BattleSettingsGeneratorService
    {
        private InstantiateUnitEntityService instantiateUnitEntityService;

        public void SetData(InstantiateUnitEntityService instantiateUnitEntityService)
        {
            this.instantiateUnitEntityService = instantiateUnitEntityService;
        }

        public IBattleSettings GenerateBattle(IEnumerable<string> playerUnitsIds, IEnumerable<string> rivalsUnitsIds, IEnumerable<string > playerDeck)
        {
            var battleSettings = new BattleSettings
            {
                PlayerDeck = playerDeck
            };
            
            foreach (var unitId in playerUnitsIds)
            {
                var controller = instantiateUnitEntityService.Instantiate<GenericEntityController>(unitId);
                controller.Team = (uint)IBattleSettings.Team.PLAYER;
                battleSettings.AddEntityToPlayer(controller.Id);
            }
            foreach (var unitId in rivalsUnitsIds)
            {
                var controller = instantiateUnitEntityService.Instantiate<GenericEntityController>(unitId);
                controller.Team = (uint)IBattleSettings.Team.RIVAL;
                battleSettings.AddEntityToRival(controller.Id);
            }

            return battleSettings;
        }
    }
}