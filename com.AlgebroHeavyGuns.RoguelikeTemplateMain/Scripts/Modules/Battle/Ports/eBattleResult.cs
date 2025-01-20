namespace Battle.Ports
{
    public enum eBattleResult
    {
        BAD_STATE = -1,
        IN_PROGRESS = 0,
        PLAYER_WINS = 10,
        ENEMY_WINS = 20,
        RUN_AWAY = 99,
    }
}