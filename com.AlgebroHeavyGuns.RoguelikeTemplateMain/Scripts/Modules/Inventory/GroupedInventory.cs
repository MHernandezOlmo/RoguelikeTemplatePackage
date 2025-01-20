using System.Collections.Generic;
using System.Linq;
using Common;
using Inventory.Ports;

namespace Inventory
{
    public class GroupedInventory : IInventory, IRepository<IReadOnlyInventoryField, int>
    {
        private readonly Dictionary<int, InventoryField> dictionary = new();
        
        public bool TryGet(int key, out IReadOnlyInventoryField element)
        {
            var result =  dictionary.TryGetValue(key, out var field);
            element = field;
            return result;
        }
        
        public bool TryGet(int key, out IInventoryField element)
        {
            var result =  dictionary.TryGetValue(key, out var field);
            element = field;
            return result;
        }

        IReadOnlyInventoryField IRepository<IReadOnlyInventoryField, int>.Get(int key)
        {
            return dictionary[key];
        }
        IInventoryField IRepository<IInventoryField, int>.Get(int key)
        {
            return dictionary[key];
        }
        IEnumerable<IReadOnlyInventoryField> IRepository<IReadOnlyInventoryField, int>.GetElements()
        {
            return dictionary.Values;
        }
        
        IEnumerable<IInventoryField> IRepository<IInventoryField, int>.GetElements()
        {
            return dictionary.Values;
        }
        
        public void AddItem(int key, float weight, float size, int amount)
        {
            if (!dictionary.TryGetValue(key, out var field))
            {
                dictionary.Add(key, new InventoryField(key, weight, size, amount));
            }
            else
            {
                field.Amount += amount;
            }
        }

        public void RemoveItem(int key, int amount = 1)
        {
            if (!dictionary.TryGetValue(key, out var field)) return;
            field.Amount -= amount;
            if (field.Amount < 1) 
                dictionary.Remove(field.ItemKey);
        }

        public int Count(int key)
        {
            return dictionary.TryGetValue(key, out var field) ? field.Amount : 0;
        }

        public float TotalWeight()
        {
            return dictionary.Values.Sum(field => field.Weight);
        }

        public float TotalSize()
        {
            return dictionary.Values.Sum(field => field.Size);
        }

        public void Clear()
        {
            dictionary.Clear();
        }
    }
}