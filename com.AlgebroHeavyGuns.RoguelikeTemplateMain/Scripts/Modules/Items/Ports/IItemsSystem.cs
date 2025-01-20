using System;
using System.Collections.Generic;

namespace Items.Ports
{
    public interface IItemsSystem
    {
        bool TryGetItem(int key, out IItemModel itemModel);
        IItemModel GetItem(int key);
        IEnumerable<IItemModel> GetAllItems();
        IEnumerable<IItemModel> GetItemsIfCondition(Predicate<IItemModel> condition);
    }
}