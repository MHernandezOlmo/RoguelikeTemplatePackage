using Battle.Ports;
using Game.Entities;
using Game.UI.Services;

namespace Game.Battle
{
    public class BattleFlowEventsEmitter : IBattleFlowEventsEmitter
    {
        private EntitiesFlowEventsListener entitiesEventsListener;
        private UIBattleFlowEventsListener uiBattleFlowEventsListener;

        public void SetData(EntitiesFlowEventsListener entitiesEventsListener, UIBattleFlowEventsListener uiBattleFlowEventsListener)
        {
            this.entitiesEventsListener = entitiesEventsListener;
            this.uiBattleFlowEventsListener = uiBattleFlowEventsListener;
        }

        public void OnTurnChanged(IBattleSettings.Team currentTurnTeam)
        {
            entitiesEventsListener.OnTurnChanged(currentTurnTeam);
            uiBattleFlowEventsListener.OnTurnChanged(currentTurnTeam);
        }
    }
}