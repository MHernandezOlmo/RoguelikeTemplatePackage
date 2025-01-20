using System;
using System.Collections.Generic;
using User.Persistence;

namespace User.Ports
{
    public interface IUserInventory
    {
        IEnumerable<Tuple<int, int>> GetAllItems();
        int GetItemAmount(int itemKey);
        void AddItem(int itemKey, int amount = 1);
        void RemoveItem(int itemKey, int amount = 1);
        void Clear();
        

        
        UserInventoryPersistentData GenerateInventoryPersistentData();
        void LoadInventoryPersistentData(UserInventoryPersistentData data);
    }
}