using System.Collections.Generic;
using Entities.Ports;

namespace Entities.Services
{
    public class EntityAlteredStateManager : IEntityAlteredStateManager
    {
        private readonly Dictionary<string, AlteredStateNode> alteredStateNodes = new ();

        public IEnumerable<IEntityAlteredState> AlteredStates => alteredStateNodes.Values;

        public bool TryGetAlteredState(string alteredStateKey, out IEntityAlteredState state)
        {
            var result = alteredStateNodes.TryGetValue(alteredStateKey, out var stateNode);
            state = stateNode;
            return result;
        }
        public void AddAlteredState(string key, int duration, int accumulations, bool extendDuration = false)
        {
            if (alteredStateNodes.TryGetValue(key, out var currentNode))
            {
                currentNode.Accumulations += accumulations;
                if (extendDuration) currentNode.Duration += duration;
            }
            else
            {
                alteredStateNodes.Add(key, new AlteredStateNode(key, accumulations, duration));
            }
        }

        public void RemoveAlteredState(string key)
        {
            alteredStateNodes.Remove(key);
        }

        public void RemoveAlteredStates(string key, int accumulations)
        {
            if (!alteredStateNodes.TryGetValue(key, out var currentNode)) return;
            if (currentNode.Accumulations <= accumulations) alteredStateNodes.Remove(key);
            currentNode.Accumulations -= accumulations;
        }

        private class AlteredStateNode : IEntityAlteredState
        {
            public string Key { get; }
            public int Accumulations { get; set; }
            public int Duration { get; set; }

            public AlteredStateNode(string key, int accumulations= 1, int duration = 1) { Key = key;  Accumulations = accumulations;  Duration = duration;  }
        }
    }
}