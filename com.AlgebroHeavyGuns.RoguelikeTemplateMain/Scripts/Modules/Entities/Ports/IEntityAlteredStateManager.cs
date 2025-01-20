using System.Collections.Generic;

namespace Entities.Ports
{
    public interface IEntityAlteredStateManager
    {
        IEnumerable<IEntityAlteredState> AlteredStates { get; }
        bool TryGetAlteredState(string alteredStateKey, out IEntityAlteredState state);
        void AddAlteredState(string key, int duration=1, int accumulations = 1, bool extendDuration = false);
        void RemoveAlteredState(string key);
        void RemoveAlteredStates(string key, int accumulations);
    }
}