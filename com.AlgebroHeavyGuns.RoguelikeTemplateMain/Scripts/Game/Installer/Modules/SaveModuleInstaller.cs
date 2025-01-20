using Core.Install.Base;
using Core.Install.Ports;
using Core.Save;
using Core.Save.Ports;
using Game.Save.Services;

namespace Game.Installer.Modules
{
    public class SaveModuleInstaller : ISystemInstaller
    {
        private readonly PersistentService<PersistentData> persistentService = new ();
        private readonly GamePersistentRepository gamePersistentRepository = new(); 
        private readonly GamePersistentAdapterPlayerPrefs gamePersistentAdapter = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<ISaveService>(persistentService);
            referencesLocator.AddReference<ILoadService>(persistentService);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            gamePersistentRepository.Install(referencesLocator);
            persistentService.SetData(gamePersistentRepository, gamePersistentAdapter);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<ISaveService>();
            referencesLocator.RemoveReference<ILoadService>();
        }

        public void Initialize()
        {
            persistentService.Initialize();
        }

        public void Dispose()
        {
            persistentService.Dispose();
        }

        public void Tick(float deltaTime)
        {
            persistentService.Tick(deltaTime);
        }
    }
}