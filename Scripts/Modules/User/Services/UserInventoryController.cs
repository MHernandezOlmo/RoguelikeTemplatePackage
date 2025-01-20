using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Inventory;
using Inventory.Ports;
using User.Persistence;
using User.Ports;

namespace User.Services
{
    public class UserInventoryController : IUserInventory
    {
        private readonly GroupedInventory inventory = new();

        public IEnumerable<Tuple<int, int>> GetAllItems()
        {
            return ((IRepository<IReadOnlyInventoryField, int>)inventory).GetElements()
                .Select(item => new Tuple<int, int>(item.ItemKey, item.Amount));
        }

        public int GetItemAmount(int itemKey) =>
            inventory.TryGet(itemKey, out IReadOnlyInventoryField element) ? element.Amount : 0;

        public void AddItem(int itemKey, int amount = 1)
        {
            inventory.AddItem(itemKey, 0, 0, amount);
        }

        public void RemoveItem(int itemKey, int amount = 1)
        {
            inventory.RemoveItem(itemKey, amount);
        }

        public void Clear()
        {
            inventory.Clear();
        }

        public UserInventoryPersistentData GenerateInventoryPersistentData()
        {
            return new UserInventoryPersistentData()
            {
                inventoryData = ((IInventory)inventory).GetElements().Select(element =>
                    new UserInventoryFieldPersistentData()
                    {
                        amount = element.Amount,
                        itemKey = element.ItemKey
                    }).ToArray()
            };
        }

        public void LoadInventoryPersistentData(UserInventoryPersistentData data)
        {
            foreach (var fieldData in data.inventoryData)
            {
                inventory.AddItem(fieldData.itemKey, 0, 0, fieldData.amount);
            }
        }
    }
}