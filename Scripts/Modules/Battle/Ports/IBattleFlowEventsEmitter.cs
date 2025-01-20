namespace Battle.Ports
{
    public interface IBattleFlowEventsEmitter
    {
        void OnTurnChanged(IBattleSettings.Team currentTurn);
    }
}