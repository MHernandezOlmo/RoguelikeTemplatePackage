using Common;

namespace Inventory.Ports
{
    public interface IInventory : IRepository<IInventoryField>
    {
        void AddItem(int key, float weight, float size, int amount = 1);
        void RemoveItem(int key, int amount = 1);
        int Count(int key);
        float TotalWeight();
        float TotalSize();
        void Clear();
    }
}