using System.Collections.Generic;
using Inventory.Equipment;
using Items.Ports;

namespace Inventory.Ports
{
    public interface IItemFromInventoryDataConverterService
    {
        IEnumerable<IItemModel> ConvertEquipment(EquipmentController equipment);
        float GetBonusFromEquipment(string bonusId, EquipmentController equipment);
        float GetBonusFromInventory(string bonusId, IInventory inventory);
    }
}