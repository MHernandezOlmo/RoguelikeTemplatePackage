using System.Collections.Generic;
using System.Linq;
using Battle.Ports;
using UnityEngine;

namespace Battle
{
    public class PlayerDeck : IPlayerDeck
    {
        private Queue<string> availableDeck;
        private List<string> usedDeck;

        public PlayerDeck()
        {
            availableDeck = new Queue<string>();
            usedDeck = new List<string>();
        }
        public PlayerDeck(IEnumerable<string> deck)
        {
            availableDeck = new Queue<string>(deck);
            usedDeck = new();
        }

        public void RegenerateDeck(IEnumerable<string> deck)
        {
            availableDeck = new Queue<string>(deck);
            usedDeck = new();
        }

        public int DeckSize => availableDeck.Count;
        public int UsedSize => usedDeck.Count;
        public IEnumerable<string> UsedCards => usedDeck;

        public IPlayerDeck.ActionResult GetNext()
        {
            var hasShuffle = false;
            if (!availableDeck.TryDequeue(out var nextCard))
            {
                Shuffle();
                hasShuffle = true;
                nextCard = availableDeck.Dequeue();
            }

            return new IPlayerDeck.ActionResult()
            {
                Card = nextCard, HasShuffle = hasShuffle, HasNext = nextCard.Length > 0
            };
        }

        public void Shuffle()
        {
            availableDeck = new Queue<string>(usedDeck.OrderBy(x => Random.value));
            usedDeck.Clear();
        }

        public void AddToDeck(string newAvailableCard)
        {
            availableDeck.Enqueue(newAvailableCard);
        }

        public void AddToUsed(string newUsedCard)
        {
            usedDeck.Add(newUsedCard);
        }
    }
}