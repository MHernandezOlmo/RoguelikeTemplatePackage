namespace Battle.Ports
{
    public interface IBattleSystem
    {
        IBattleController Battle { get; }
        IBattleController CreateBattle(IBattleSettings settings);
        void CloseBattle();
        bool IsBattleActive { get; }
    }
}