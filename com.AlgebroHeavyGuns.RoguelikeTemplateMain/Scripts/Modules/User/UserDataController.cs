using User.Ports;

namespace User
{
    public class UserDataController : IUserController
    {
        public readonly UserDataModel model;
        
        public IUserDataModel Model => model;
        public IUserInventory Inventory { get; }


        private IUserDataEventsEmitter eventsEmitter;
        
        public void OnInitAdventure()
        {
            model.HasActiveAdventure = true;
            eventsEmitter.OnUserDataChanged();
        }

        public UserDataController(UserDataModel model, IUserInventory inventory, IUserDataEventsEmitter eventsEmitter)
        {
            this.model = model;
            this.eventsEmitter = eventsEmitter;
            Inventory = inventory;
        }
        
        
        public void Reset(UserDataModel userDataModel)
        {
            model.HasActiveAdventure = userDataModel.HasActiveAdventure;
            model.Gold = 0;
        }
    }
}