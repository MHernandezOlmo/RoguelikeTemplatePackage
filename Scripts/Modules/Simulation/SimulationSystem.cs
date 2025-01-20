using System;
using System.Collections.Generic;
using Simulation.Ports;
using UnityEngine.Assertions;

namespace Simulation.Ports
{
    public interface ISimulationSystem
    {
        void Simulate<T>(IBoardState board, T simulationParams);
        IEnumerable<(IUnitEntityState, float)> PreviewHealthVariation<T>(IBoardState board, T simulationParams);
    }

    public interface IUnitEntityState
    {
        int UnitId { get; }
        uint Team { get; }
        float GetCurrentAttribute(int attribute, float defaultValue=0f);
        float GetMaxAttribute(int attribute, float defaultValue=0f);
        bool TryGetAlteredStateAccumulations(string alteredState, out int accumulations);
    }

    public interface IBoardState
    {
        IEnumerable<IUnitEntityState> UnitsStates { get; }
        bool TryGetUnitWithId(int id, out IUnitEntityState unitState);
        void ApplyCurrentHealthVariationTo(ApplicationParams.HealthVariationParams applicationParams);
    }

    public interface IActionApplicatorRepository
    {
        Dictionary<Type, object> GenerateApplicators();
    }
    
    public interface IActionApplicator<in T>
    {
        void Apply(IBoardState boardState, T actionParams);
        IEnumerable<(IUnitEntityState, float)> GetPreview(IBoardState boardState, T actionParams);
    }
}

namespace Simulation
{
    public class SimulationSystem : ISimulationSystem
    {
        private Dictionary<Type, object> applicators;
        private IActionApplicatorRepository applicatorRepository;

        public void SetData(IActionApplicatorRepository actionApplicatorRepository)
        {
            applicatorRepository = actionApplicatorRepository;
        }
        
        public void Simulate<T>(IBoardState board, T simulationParams)
        {
            var applicator = GetApplicator<T>();
            applicator.Apply(board, simulationParams);
        }

        public IEnumerable<(IUnitEntityState, float)> PreviewHealthVariation<T>(IBoardState board, T simulationParams)
        {
            var applicator = GetApplicator<T>();
            return applicator.GetPreview(board, simulationParams);
        }

        private IActionApplicator<T> GetApplicator<T>()
        {
            var applicatorType = typeof(T);
            if (!applicators.TryGetValue(applicatorType, out var applicator))
            {
                throw new ArgumentException($"Not expected parameter of type {applicatorType} on Simulation System. Type not found, check it on IActionApplicatorRepository implementation.");
            }

            var actionApplicator = applicator as IActionApplicator<T>;
            Assert.IsNotNull(applicator);
            return actionApplicator;
        }
        
        public void Initialize()
        {
            applicators = applicatorRepository.GenerateApplicators();
        }

        public void Dispose()
        {
            applicators.Clear();
        }
    }
}
