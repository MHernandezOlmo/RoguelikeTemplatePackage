using System;
using System.Collections.Generic;
using System.Linq;
using Game.Battle;
using Game.Battle.Services;
using Items.Ports;
using User.Ports;


namespace Game.Items
{
    public class ItemsBattleActionsTriggerListener
    {
        private IItemsSystem itemsSystem;
        private IUserDataSystem userDataSystem;
        private BattleTriggerActionApplicator battleTriggerActionApplicator;

        private List<KeyValuePair<IItemModel, int>> userItems;

        public void SetData(IItemsSystem itemsSystem, IUserDataSystem userDataSystem, BattleTriggerActionApplicator battleTriggerActionApplicator)
        {
            this.itemsSystem = itemsSystem;
            this.userDataSystem = userDataSystem;
            this.battleTriggerActionApplicator = battleTriggerActionApplicator;
        }

        public void OnBattleStarted()
        {
            userItems = userDataSystem.Controller.Inventory.GetAllItems()
                .Select(itemPair => 
                    new KeyValuePair<IItemModel, int>(itemsSystem.GetItem(itemPair.Item1), itemPair.Item2))
                .ToList();
        }
        
        public void OnEventTriggered(eBattleTrigger trigger, Predicate<IItemModel> condition = null)
        {
            foreach (var itemPair in userItems)
            {
                var triggersToApply = GetItemsToApplyTrigger(itemPair, trigger, condition);
                ApplyTriggers(triggersToApply, itemPair.Value);
                
            }
        }

        private void ApplyTriggers(IEnumerable<KeyValuePair<int, string>> triggersToApply, int occurrences)
        {
            foreach (var (trigger, skillId) in triggersToApply)
            {
                for (var i = 0; i < occurrences; ++i)
                    battleTriggerActionApplicator.ApplyTrigger(skillId);
            }

        }

        private static IEnumerable<KeyValuePair<int, string>> GetItemsToApplyTrigger(KeyValuePair<IItemModel, int> item,
            eBattleTrigger trigger, Predicate<IItemModel> condition)
        {
            return item.Key.StaticData.SkillTriggers
                .Where(skillTrigger => skillTrigger.Key == (int)trigger && (condition?.Invoke(item.Key) ?? true));
        }
        
    }
}