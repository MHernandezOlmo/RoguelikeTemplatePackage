using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Ports;

namespace Battle
{
    public class BattleModel : IBattleModel
    {
        public IEnumerable<int> EntitiesIdsTeam(IBattleSettings.Team team) =>
            entities.TryGetValue(team, out var teamEntities) ? teamEntities : Array.Empty<int>();

        public IPlayerDeck PlayerDeck => playerDeck;
        public IEnumerable<string> PlayerHand => playerHand;
        

        private readonly Dictionary<IBattleSettings.Team, List<int>> entities;
        private readonly List<string> playerHand = new();
        private readonly PlayerDeck playerDeck;
        
        public IBattleSettings.Team CurrentTurn { get; set; }

        public BattleModel(IBattleSettings settings)
        {
            entities = new()
            {
                { IBattleSettings.Team.PLAYER, settings.PlayerEntitiesIds.ToList() },
                { IBattleSettings.Team.RIVAL, settings.RivalEntitiesIds.ToList() }
            };
            playerDeck = new PlayerDeck(settings.PlayerDeck);
        }

        public void Dispose()
        {
            entities.Clear();
        }
        
    }
}