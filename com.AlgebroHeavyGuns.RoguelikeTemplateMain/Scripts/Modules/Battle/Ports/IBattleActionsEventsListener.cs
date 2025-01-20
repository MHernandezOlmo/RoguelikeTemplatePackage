namespace Battle.Ports
{
    public interface IBattleActionsTriggerEventsListener
    {
        void OnTurnChanged(IBattleSettings.Team currentTeam);
        void OnStartBattle();
        void OnEndBattle();
        void OnActionDone();
    }
}
