using Entities.Ports;
using Simulation.Ports;

namespace Game.Simulation
{
    public class GameSimulatedUnitEntity : IUnitEntityState
    {
        private readonly IEntityController entityController;
        
        public GameSimulatedUnitEntity(IEntityController entityController)
        {
            this.entityController = entityController;
        }

        public int UnitId => entityController.Id;
        public uint Team => entityController.Team;

        public float GetCurrentAttribute(int attribute, float defaultValue=0f) =>
            entityController.Model.TryGetCurrentAttribute(attribute, out var value) ? value : defaultValue;

        public float GetMaxAttribute(int attribute, float defaultValue=0f) => 
            entityController.Model.TryGetMaxAttribute(attribute, out var value) ? value : defaultValue;

        public bool TryGetAlteredStateAccumulations(string alteredStateKey, out int accumulations)
        {
            accumulations = 0;
            if (!entityController.Model.AlteredStateManager.TryGetAlteredState(alteredStateKey,
                    out var alteredStateNode)) return false;
            accumulations = alteredStateNode.Accumulations;
            return true;
        }
    }
}