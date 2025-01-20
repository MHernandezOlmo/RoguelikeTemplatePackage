using System;
using System.Collections.Generic;
using System.Linq;
using Items.Ports;

namespace Items
{
    public class ItemsSystem : IItemsSystem
    {
        private Dictionary<int, ItemModel> itemModels;
        private IItemStaticDataRepository itemStaticDataRepository;

        public void SetData(IItemStaticDataRepository itemStaticDataRepository)
        {
            this.itemStaticDataRepository = itemStaticDataRepository;
        }

        public void Initialize()
        {
            itemModels = itemStaticDataRepository.GetElements().ToDictionary(
                x => x.Id, 
                x => new ItemModel(x));
        }

        public void Dispose()
        {
            itemModels.Clear();
            itemModels = null;
        }

        public IItemModel GetItem(int key) => itemModels[key];

        public IEnumerable<IItemModel> GetAllItems()
        {
            return itemModels.Values;
        }

        public IEnumerable<IItemModel> GetItemsIfCondition(Predicate<IItemModel> condition)
        {
            return itemModels.Values.Where(condition.Invoke);
        }

        public bool TryGetItem(int key, out IItemModel itemModel)
        {
            itemModel = null;
            if(!itemModels.TryGetValue(key, out var model)) return false;
            itemModel = model;
            return true;
        }
    }
}


