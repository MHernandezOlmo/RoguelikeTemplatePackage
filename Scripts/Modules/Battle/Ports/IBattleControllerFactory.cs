namespace Battle.Ports
{
    public interface IBattleControllerFactory
    {
        BattleController Create(IBattleSettings settings);
    }
}