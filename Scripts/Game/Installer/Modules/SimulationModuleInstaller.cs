using Core.Install.Base;
using Core.Install.Ports;
using Simulation;
using Simulation.Ports;


namespace Game.Installer.Modules
{
    public class SimulationModuleInstaller  : ISystemInstaller
    {
        //DOMAIN
        private readonly SimulationSystem simulationSystem = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<ISimulationSystem>(simulationSystem);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var actionApplicatorRepository = referencesLocator.GetReference<IActionApplicatorRepository>();
            simulationSystem.SetData(actionApplicatorRepository);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<ISimulationSystem>();
        }

        public void Initialize()
        {
            simulationSystem.Initialize();
        }

        public void Dispose()
        {
            simulationSystem.Dispose();
        }

        public void Tick(float deltaTime)
        {

        }
    }

}

