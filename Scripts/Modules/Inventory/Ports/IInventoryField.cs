namespace Inventory.Ports
{
    public interface IInventoryField : IReadOnlyInventoryField
    {
        new int Amount { get; set; }
    }
}