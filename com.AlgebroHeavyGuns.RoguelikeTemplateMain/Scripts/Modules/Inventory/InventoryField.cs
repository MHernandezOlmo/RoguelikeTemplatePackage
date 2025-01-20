using Inventory.Ports;

namespace Inventory
{
    public class InventoryField : IInventoryField
    {
        public int ItemKey { get; }
        public float Weight => weightForItem * Amount;
        public float Size => sizeForItem * Amount;
        public int Amount { get; set; }

        private readonly float weightForItem;
        private readonly float sizeForItem;
        
        public InventoryField(int itemKey, float weightForItem, float sizeForItem, int amount=1)
        {
            ItemKey = itemKey;
            Amount = amount;
            this.weightForItem = weightForItem;
            this.sizeForItem = sizeForItem;
        }
    }
}