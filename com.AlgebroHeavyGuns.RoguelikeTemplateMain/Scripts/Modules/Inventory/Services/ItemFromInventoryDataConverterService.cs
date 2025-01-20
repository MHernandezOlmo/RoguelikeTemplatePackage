using System.Collections.Generic;
using System.Linq;
using Inventory.Equipment;
using Inventory.Ports;
using Items.Ports;

namespace Inventory.Services
{
    public class ItemFromInventoryDataConverterService : IItemFromInventoryDataConverterService
    {
        private IItemsSystem itemsSystem;

        public void SetData(IItemsSystem itemsSystem)
        {
            this.itemsSystem = itemsSystem;
        }

        public IEnumerable<IItemModel> ConvertEquipment(EquipmentController equipment)
        {
            var itemsIds = equipment.GetEquippedItems();
            return itemsIds.Select(item => itemsSystem.GetItem(item));
        }

        public float GetBonusFromEquipment(string bonusId, EquipmentController equipment)
        {
            var itemsIds = equipment.GetEquippedItems();
            return GetSpecificBonusFromItems(bonusId, itemsIds);
        }

        public float GetBonusFromInventory(string bonusId, IInventory inventory)
        {
            var itemsIds = inventory.GetElements().Select(field => field.ItemKey);
            return GetSpecificBonusFromItems(bonusId, itemsIds);
        }

        private float GetSpecificBonusFromItems(string bonusId, IEnumerable<int> itemsIds)
        {
            var items = itemsIds.Select(item => itemsSystem.GetItem(item));
            var accumulateBonus = 0f;
            foreach (var itemModel in items)
            {
                if (itemModel.Attributes.TryGetBonus(bonusId, out var bonusValue))
                    accumulateBonus += bonusValue;
            }
            return accumulateBonus;
        }
    }
}