using Core.Install.Base;
using Core.Install.Ports;
using Items;
using Items.Ports;


namespace Game.Installer.Modules
{
    public class ItemsModuleInstaller : ISystemInstaller
    {
        //DOMAIN
        private readonly ItemsSystem itemsSystem = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IItemsSystem>(itemsSystem);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var itemStaticDataRepository = referencesLocator.GetReference<IItemStaticDataRepository>();
            
            itemsSystem.SetData(itemStaticDataRepository);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IItemsSystem>();
        }

        public void Initialize()
        {
            itemsSystem.Initialize();
        }

        public void Dispose()
        {
            itemsSystem.Dispose();
        }

        public void Tick(float deltaTime)
        {
            //itemsSystem.Tick(deltaTime);
        }
    }
}
