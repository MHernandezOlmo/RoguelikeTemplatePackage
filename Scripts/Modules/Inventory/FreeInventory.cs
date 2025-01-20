using System.Collections.Generic;
using System.Linq;
using Common;
using Inventory.Ports;

namespace Inventory
{
    public class FreeInventory : IInventory, IRepository<IReadOnlyInventoryField, int>
    {
        private readonly List<IInventoryField> inventoryFields = new();
        
        IEnumerable<IInventoryField> IRepository<IInventoryField, int>.GetElements()
        {
            return inventoryFields;
        }
        
        IEnumerable<IReadOnlyInventoryField> IRepository<IReadOnlyInventoryField, int>.GetElements()
        {
            return inventoryFields;
        }

        public bool TryGet(int key, out IReadOnlyInventoryField element)
        {
            element = inventoryFields.FirstOrDefault(x => x.ItemKey == key);
            return element != default;
        }
        
        public bool TryGet(int key, out IInventoryField element)
        {
            element = inventoryFields.FirstOrDefault(x => x.ItemKey == key);
            return element != default;
        }
        
        IReadOnlyInventoryField IRepository<IReadOnlyInventoryField, int>.Get(int key)
        {
            return  inventoryFields.FirstOrDefault(x => x.ItemKey == key);
        }

        public void AddItem(int key, float weight, float size, int amount = 1)
        {
            inventoryFields.Add(new InventoryField(key, weight, size, amount));
        }

        public void RemoveItem(int key, int amount = 1)
        {
            var fields = inventoryFields.Where(x => x.ItemKey == key).ToArray();
            foreach (var inventoryField in fields)
            {
                if (amount < inventoryField.Amount)
                {
                    inventoryField.Amount -= amount;
                    return;
                }
                if (amount == inventoryField.Amount)
                {
                    inventoryFields.Remove(inventoryField);
                    return;
                }
                
                amount -= inventoryField.Amount;
                inventoryFields.Remove(inventoryField);
            }
        }

        public int Count(int key)
        {
           return inventoryFields.Where(x => x.ItemKey == key).Sum(x => x.Amount);
        }

        public float TotalWeight()
        {
            return inventoryFields.Sum(field => field.Weight);
        }

        public float TotalSize()
        {
            return inventoryFields.Sum(field => field.Size);
        }

        public void Clear()
        {
            inventoryFields.Clear();
        }

        IInventoryField IRepository<IInventoryField, int>.Get(int key)
        {
            return  inventoryFields.FirstOrDefault(x => x.ItemKey == key);
        }
        
        public IInventoryField GetPosition(int position) => inventoryFields[position];

        public bool Combine(int positionA, int positionB)
        {
            var elementA = inventoryFields[positionA];
            var elementB = inventoryFields[positionB];
            if (elementA.ItemKey != elementB.ItemKey) return false;
            
            inventoryFields.RemoveAt(positionB);
            elementA.Amount += elementB.Amount;
            return true;
        }
    }
}