using System.Collections.Generic;

namespace Battle.Ports
{
    public interface IPlayerDeck
    {
        int DeckSize { get; }
        int UsedSize { get; }
        IEnumerable<string> UsedCards { get; }
        ActionResult GetNext();     //Will shuffle if it is required.
        void Shuffle();
        void AddToDeck(string newAvailableCard);
        void AddToUsed(string newUsedCard);
        
        public struct ActionResult
        {
            public string Card;
            public bool HasShuffle;
            public bool HasNext;
        }
    }
}