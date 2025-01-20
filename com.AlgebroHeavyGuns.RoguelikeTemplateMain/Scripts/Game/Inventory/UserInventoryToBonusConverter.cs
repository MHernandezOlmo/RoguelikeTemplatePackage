using System;
using System.Linq;
using Items.Ports;
using User.Ports;

namespace Game.Inventory
{
    public class UserInventoryToBonusConverter
    {
        private static readonly UserInventoryToBonusConverter instance = new ();

        private IUserDataSystem userDataSystem;
        private IItemsSystem itemsSystem;

        public static void SetData(IUserDataSystem userDataSystem, IItemsSystem itemsSystem)
        {
            instance.userDataSystem = userDataSystem;
            instance.itemsSystem = itemsSystem;
        }
        
        public static float GetBonus(string bonusId)
        {
            var accumulatedBonus = 0f;
            var items = instance.userDataSystem.Controller.Inventory.GetAllItems().Select(tuple =>
                new Tuple<IItemModel, int>(instance.itemsSystem.GetItem(tuple.Item1), tuple.Item2));
            foreach (var tuple in items)
            {
                if (tuple.Item1.Attributes.TryGetBonus(bonusId, out var bonusValue))
                    accumulatedBonus += bonusValue;
            }

            return accumulatedBonus;
        }
    }
}