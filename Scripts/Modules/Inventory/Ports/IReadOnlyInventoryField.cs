namespace Inventory.Ports
{
    public interface IReadOnlyInventoryField
    {   
        int ItemKey { get; }
        float Weight { get; }
        float Size { get; }
        int Amount { get; }
    }
}