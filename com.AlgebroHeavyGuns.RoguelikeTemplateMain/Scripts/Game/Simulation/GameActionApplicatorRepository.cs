using System;
using System.Collections.Generic;
using Game.Entities;
using Game.Simulation.Applicator;
using Game.Simulation.Params;
using Simulation.Ports;

namespace Game.Simulation
{
}

namespace Game.Simulation
{
    public class GameActionApplicatorRepository : IActionApplicatorRepository
    {
        public Dictionary<Type, object> GenerateApplicators()
        {
            return new Dictionary<Type, object>()
            {
                { typeof(SimulationApplicatorParams.DirectHealthModification), new ApplicatorStandardDirectEffect()},
            };
        }
    }
}