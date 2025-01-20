using User.Ports;

namespace User.Services
{
    public class UserInventoryFactory : IUserInventoryFactory
    {
        public IUserInventory GenerateUserInventory()
        {
            return new UserInventoryController();
        }
        
    }
}
