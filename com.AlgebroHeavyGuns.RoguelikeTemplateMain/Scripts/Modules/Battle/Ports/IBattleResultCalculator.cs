namespace Battle.Ports
{
    public interface IBattleResultCalculator
    {
        eBattleResult GetResult(IBattleController battleController);
    }
}