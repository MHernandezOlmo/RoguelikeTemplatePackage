using System.Collections.Generic;

namespace Battle.Ports
{
    public interface IBattleModel
    {
        IEnumerable<int> EntitiesIdsTeam(IBattleSettings.Team team);
        IPlayerDeck PlayerDeck { get; }
        IEnumerable<string> PlayerHand { get; }
        
        IBattleSettings.Team CurrentTurn { get; }
    }
}