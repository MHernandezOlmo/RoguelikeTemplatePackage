namespace Battle.Ports
{
    public interface IBattleController
    {
        IBattleModel Model { get; }
        bool IsFinished { get; }
        bool HasQuitBattle { get; }
        eBattleResult Result { get; }

        void StartBattle();
        void QuitBattle();
        void OnUnitDead(int unitId);
        void GoNextTurn();
    }
}