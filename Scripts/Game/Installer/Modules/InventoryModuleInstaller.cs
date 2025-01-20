using Core.Install.Base;
using Core.Install.Ports;
using Inventory.Ports;
using Inventory.Services;
using Items.Ports;

namespace Game.Installer.Modules
{
    public class InventoryModuleInstaller : ISystemInstaller
    {
       
        //SERVICES
        private readonly ItemFromInventoryDataConverterService itemFromInventoryDataConverterService = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IItemFromInventoryDataConverterService>(itemFromInventoryDataConverterService);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var itemsSystem = referencesLocator.GetReference<IItemsSystem>();
            
            itemFromInventoryDataConverterService.SetData(itemsSystem);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IItemFromInventoryDataConverterService>();
        }

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }

        public void Tick(float deltaTime)
        {
      
        }
    }
}