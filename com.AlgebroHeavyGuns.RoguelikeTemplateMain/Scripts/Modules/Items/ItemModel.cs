using System.Collections.Generic;
using Items.Ports;

namespace Items
{
    public class ItemModel : IItemModel
    {
        public IItemStaticData StaticData { get; }
        public int Level => 1;
        public IItemLevelingData Attributes => StaticData.AttributesAtLevel(Level - 1);

        public ItemModel(IItemStaticData staticData)
        {
            StaticData = staticData;
        }
    }
}