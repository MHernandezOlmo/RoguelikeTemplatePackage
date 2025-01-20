using Battle.Ports;
using Game.Entities;
using Game.Items;

namespace Game.Battle
{
    public class BattleActionsStatsController
    {
        public int CurrentTurnActions { get; private set; }
        public int BattleTotalActions { get; private set; }
        public int PreviousTurnActions { get; private set; }

        public void OnActionDone()
        {
            CurrentTurnActions += 1;
            BattleTotalActions += 1;
        }

        public void OnTurnChanged()
        {
            PreviousTurnActions = CurrentTurnActions;
            CurrentTurnActions = 0;
        }
    }
    
    public class BattleActionsTriggerEventsListener : IBattleActionsTriggerEventsListener
    {
        private ItemsBattleActionsTriggerListener itemsBattleActionsTriggerListener;
        private EntitiesBattleActionsTriggerListener entitiesBattleActionsTriggerListener;
        private BattleActionsStatsController battleActionsStatsController = new();

        private IBattleSettings.Team cachedTeamTurn;

        public void SetData(ItemsBattleActionsTriggerListener itemsBattleActionsTriggerListener, EntitiesBattleActionsTriggerListener entitiesBattleActionsTriggerListener)
        {
            this.itemsBattleActionsTriggerListener = itemsBattleActionsTriggerListener;
            this.entitiesBattleActionsTriggerListener = entitiesBattleActionsTriggerListener;
        }
        
        public void OnTurnChanged(IBattleSettings.Team currentTeam)
        {
            cachedTeamTurn = currentTeam;
            battleActionsStatsController.OnTurnChanged();
            //END TURN TRIGGERS
            var endTurnTriggerEvent = currentTeam == IBattleSettings.Team.PLAYER ? eBattleTrigger.END_ENEMY_TURN : eBattleTrigger.END_PLAYER_TURN;
            itemsBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.END_ANY_TURN);
            itemsBattleActionsTriggerListener.OnEventTriggered(endTurnTriggerEvent);
            entitiesBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.END_ANY_TURN);
            entitiesBattleActionsTriggerListener.OnEventTriggered(endTurnTriggerEvent);
            
            //START TURN TRIGGERS
            var startTurnTriggerEvent = currentTeam == IBattleSettings.Team.PLAYER ? eBattleTrigger.START_PLAYER_TURN : eBattleTrigger.START_ENEMY_TURN;
            itemsBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.START_ANY_TURN);
            itemsBattleActionsTriggerListener.OnEventTriggered(startTurnTriggerEvent);
            entitiesBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.START_ANY_TURN);
            entitiesBattleActionsTriggerListener.OnEventTriggered(startTurnTriggerEvent);
        }

        public void OnStartBattle()
        {
            itemsBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.START_BATTLE);
            entitiesBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.START_BATTLE);
        }

        public void OnEndBattle()
        {
            itemsBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.END_BATTLE);
            entitiesBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.END_BATTLE);
        }

        public void OnActionDone()
        {
            battleActionsStatsController.OnActionDone();
            if (battleActionsStatsController.CurrentTurnActions == 1)
            {
                var actionTrigger = cachedTeamTurn == IBattleSettings.Team.PLAYER ? eBattleTrigger.FIRST_ACTION_TURN_PLAYER : eBattleTrigger.FIRST_ACTION_TURN_ENEMY;
                itemsBattleActionsTriggerListener.OnEventTriggered(actionTrigger);
                entitiesBattleActionsTriggerListener.OnEventTriggered(actionTrigger);
            }
            if (battleActionsStatsController.CurrentTurnActions == 2)
            {
                var actionTrigger = cachedTeamTurn == IBattleSettings.Team.PLAYER ? eBattleTrigger.SECOND_ACTION_TURN_PLAYER : eBattleTrigger.SECOND_ACTION_TURN_ENEMY;
                itemsBattleActionsTriggerListener.OnEventTriggered(actionTrigger);
                entitiesBattleActionsTriggerListener.OnEventTriggered(actionTrigger);
            }
            var actionTriggerEvent = cachedTeamTurn == IBattleSettings.Team.PLAYER ? eBattleTrigger.ANY_ACTION_TURN_PLAYER : eBattleTrigger.ANY_ACTION_TURN_ENEMY;
            itemsBattleActionsTriggerListener.OnEventTriggered(actionTriggerEvent);
            entitiesBattleActionsTriggerListener.OnEventTriggered(actionTriggerEvent);
            itemsBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.ANY_ACTION_ANY_TURN);
            entitiesBattleActionsTriggerListener.OnEventTriggered(eBattleTrigger.ANY_ACTION_ANY_TURN);
        }
    }
}