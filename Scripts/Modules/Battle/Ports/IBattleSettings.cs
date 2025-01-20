using System.Collections.Generic;

namespace Battle.Ports
{
    public interface IBattleSettings
    {   
        IEnumerable<int> PlayerEntitiesIds { get; }
        IEnumerable<int> RivalEntitiesIds { get; }
        IEnumerable<string> PlayerDeck { get; }
        

        enum Team : uint
        {
            PLAYER, 
            RIVAL
        }
    }
}