using Core.Install.Base;
using Core.Install.Ports;
using Core.Save.Ports;
using Game.User;
using User;
using User.Persistence;
using User.Ports;
using User.Services;

namespace Game.Installer.Modules
{
    public class UserModuleInstaller : ISystemInstaller
    {
        //DOMAIN
        private readonly UserDataSystem system = new ();
        
        //SERVICES
        private readonly UserInventoryFactory userInventoryFactory = new();
        private readonly UserEventsEmitter userEventsEmitter = new();
        
        public void DefineReferences(IReferencesRepository referencesRepository)
        {
            referencesRepository.AddReference<IUserDataSystem>(system);
            referencesRepository.AddReference<IUserModulePersistence>(new UserModulePersistence(system));
        }

        public void Install(IReferencesRepository referencesRepository)
        {
            userEventsEmitter.SetData(referencesRepository.GetReference<ISaveService>());
            
            system.SetData(userInventoryFactory, userEventsEmitter);
        }
        
        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IUserDataSystem>();
            referencesLocator.RemoveReference<IUserModulePersistence>();
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