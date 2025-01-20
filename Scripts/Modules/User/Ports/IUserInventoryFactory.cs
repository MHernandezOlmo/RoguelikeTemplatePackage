namespace User.Ports
{
    public interface IUserInventoryFactory
    {
        IUserInventory GenerateUserInventory();
        
    }
}