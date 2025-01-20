using Core.Install.Base;
using Core.Install.Ports;
using Core.Save.Ports;
using Game.Statistics;
using Statistics;
using Statistics.Persistence;
using Statistics.Ports;

namespace Game.Installer.Modules
{
    public class StatisticsModuleInstaller : ISystemInstaller
    {
        //DOMAIN
        private readonly StatisticsSystem system = new ();
        
        //GAME SERVICES
        private readonly StatisticsEventsEmitter statisticsEventsEmitter = new();

        public void DefineReferences(IReferencesRepository referencesRepository)
        {
            referencesRepository.AddReference<IStatisticsSystem>(system);
            referencesRepository.AddReference<IStatisticsModulePersistence>(new StatisticsModulePersistence(system));
        }

        public void Install(IReferencesRepository referencesRepository)
        {
            var saveService = referencesRepository.GetReference<ISaveService>();
            
            statisticsEventsEmitter.SetData(saveService);
            system.SetData(statisticsEventsEmitter);
        }
        
        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IStatisticsSystem>();
            referencesLocator.RemoveReference<IStatisticsModulePersistence>();
        }

        public void Initialize()
        {
            system.Initialize();
        }

        public void Dispose()
        {
            system.Dispose();
        }

        public void Tick(float deltaTime)
        {
            //system.Tick(deltaTime);
        }
    }
}
