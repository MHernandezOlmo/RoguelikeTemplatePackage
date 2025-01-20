namespace Game.Battle
{
    public enum eBattleTrigger
    {
        START_BATTLE = 0,
        END_BATTLE = 1,
        
        START_ANY_TURN = 10,
        START_PLAYER_TURN = 15,
        START_ENEMY_TURN = 18,
        END_ANY_TURN = 30,
        END_PLAYER_TURN = 35,
        END_ENEMY_TURN = 38,
        FIRST_ACTION_TURN_PLAYER = 60,
        SECOND_ACTION_TURN_PLAYER = 61,
        FIRST_ACTION_TURN_ENEMY = 70,
        SECOND_ACTION_TURN_ENEMY = 71,
        ANY_ACTION_ANY_TURN = 80,
        ANY_ACTION_TURN_PLAYER = 81,
        ANY_ACTION_TURN_ENEMY = 82,
        
        DAMAGE_TO_PLAYER = 150,
        DAMAGE_TO_ENEMY = 200,
        
        BLOCK_ANY_DAMAGE_PLAYER = 300,
        BLOCK_ANY_DAMAGE_ENEMY = 302,
        BLOCK_ALL_DAMAGE_PLAYER = 310,
        BLOCK_ALL_DAMAGE_ENEMY = 312,
        
        GOT_ALTERED_STATE = 400,
        
    }
}