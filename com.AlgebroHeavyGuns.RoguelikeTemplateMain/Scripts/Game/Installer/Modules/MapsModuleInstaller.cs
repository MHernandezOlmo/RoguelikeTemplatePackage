using Core.Install.Base;
using Core.Install.Ports;
using Map;
using Map.Ports;
using Map.Persistence;

namespace Game.Installer.Modules
{
    public class MapsModuleInstaller : ISystemInstaller
    {
        //DOMAIN
        private readonly MapSystem system = new ();
        

        public void DefineReferences(IReferencesRepository referencesRepository)
        {
            referencesRepository.AddReference<IMapSystem>(system);
            referencesRepository.AddReference<IMapProgressModulePersistence>(new MapProgressModulePersistence(system));
        }

        public void Install(IReferencesRepository referencesRepository)
        {
            var repository = referencesRepository.GetReference<IMapsStaticRepository>();
            system.SetData(repository);
        }
        
        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IMapSystem>();
            referencesLocator.RemoveReference<IMapProgressModulePersistence>();
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