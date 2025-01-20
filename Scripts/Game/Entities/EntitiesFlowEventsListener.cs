using Battle.Ports;
using Entities.Ports;

namespace Game.Entities
{
    public class EntitiesFlowEventsListener
    {
        private IEntitiesSystem entitiesSystem;

        public void SetData(IEntitiesSystem entitiesSystem)
        {
            this.entitiesSystem = entitiesSystem;
        }

        public void OnTurnChanged(IBattleSettings.Team currentTurnTeam)
        {
            //DO THINGS ON entitiesSystem
        }
    }
}