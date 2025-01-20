using System.Collections.Generic;
using Battle.Ports;

namespace Battle.Services
{
    public class BattleSettings : IBattleSettings
    {
        public IEnumerable<int> PlayerEntitiesIds => playerEntitiesIds;
        public IEnumerable<int> RivalEntitiesIds => rivalEntitiesIds;
        public IEnumerable<string> PlayerDeck { get; set; }

        private readonly List<int> playerEntitiesIds = new();
        private readonly List<int> rivalEntitiesIds = new();
        
        public void AddEntityToPlayer(int entityId) => playerEntitiesIds.Add(entityId);
        public void AddEntityToRival(int entityId) => rivalEntitiesIds.Add(entityId);
    }
}