namespace User.Ports
{
    public interface IUserController
    {
        IUserDataModel Model { get; }
        IUserInventory Inventory { get; }

        void OnInitAdventure();
    }
}