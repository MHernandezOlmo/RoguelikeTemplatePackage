using System.Collections.Generic;
using System.Linq;

namespace Inventory.Equipment
{
    public class EquipmentController
    {
        private readonly Dictionary<string, int> equipmentSlots = new();

        public bool IsSlotEmpty(string slotKey) => equipmentSlots.ContainsKey(slotKey);
        public bool TryGetItemAtSlot(string slotKey, out int item) => equipmentSlots.TryGetValue(slotKey, out item);
        public void SetAtSlot(string slotKey, int item) => equipmentSlots[slotKey] = item;
        public bool IsEquipmentEmpty() => equipmentSlots.Keys.Count < 1;
        public bool HasItemEquipped(int itemKey) => TryGetSlotWithItemKey(itemKey, out _);
        public bool TryGetSlotWithItemKey(int itemKey, out string slotKey)
        {
            slotKey = default;
            foreach (var slotPair in equipmentSlots.Where(slotPair => slotPair.Value == itemKey))
            {
                slotKey = slotPair.Key;
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetOccupiedSlots() => equipmentSlots.Keys;
        public IEnumerable<int> GetEquippedItems() => equipmentSlots.Values;
        public IEnumerable<KeyValuePair<string, int>> GetOccupiedSlotsAndItems() => equipmentSlots;
    }

}

