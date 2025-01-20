using User.Persistence;
using User.Ports;


namespace User
{
    public class UserDataSystem : IUserDataSystem
    {
        private UserDataController controller;

        private IUserInventoryFactory inventoryFactory;
        private IUserDataEventsEmitter eventsEmitter;
        
        public IUserController Controller => controller;
        
        public void SetData(IUserInventoryFactory inventoryFactory, IUserDataEventsEmitter eventsEmitter)
        {
            this.inventoryFactory = inventoryFactory;
            this.eventsEmitter = eventsEmitter;
        }
        
        public void Initialize()
        {
            var model = new UserDataModel();
            var inventory = inventoryFactory.GenerateUserInventory();
            controller = new UserDataController(model, inventory, eventsEmitter);
        }

        public void Dispose()
        {
            controller = null;
        }
        
        public UserPersistentData GetPersistentData()
        {
            return new UserPersistentData()
            {
                hasActiveAdventure = controller.Model.HasActiveAdventure,
                inventory = controller.Inventory.GenerateInventoryPersistentData(),
                userGold = controller.model.Gold,
            };
        }
        
        public void LoadPersistentData(UserPersistentData data)
        {
            controller.model.HasActiveAdventure = data.hasActiveAdventure;
            controller.model.Gold = data.userGold;
            controller.Inventory.LoadInventoryPersistentData(data.inventory);
        }

        public void ResetPersistentData()
        {
            controller.Reset(new UserDataModel());
            controller.Inventory.Clear();
        }
    }
}