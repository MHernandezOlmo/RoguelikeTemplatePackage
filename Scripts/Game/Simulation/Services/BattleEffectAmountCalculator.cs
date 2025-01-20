using Battle.Ports;
using Game.Entities;
using Simulation.Ports;

namespace Game.Simulation.Services
{
    public static class BattleEffectAmountCalculator
    {
        public static float CalculateDamage(IUnitEntityState sourceState, IUnitEntityState targetState, float actionParamsBaseSkillHealthVariation, string skillEffectType)
        {

            if (BattleAlteredStateBonusCalculator.IsBlockingDamage(targetState, skillEffectType) ||
                BattleAlteredStateBonusCalculator.HasDamageBlocked(sourceState, skillEffectType)) return 0f;
            
            
            var damageReceivedItemModifier = 0f;//BattleItemBonusCalculator.CalculateReceivedDamageModifier(targetState, skillEffectType);      <ITEMS IS NOT GOING TO APPLY DAMAGE VARIATION>
            var damageAppliedItemModifier = 0f;//BattleItemBonusCalculator.CalculateApplyDamageModifier(sourceState, skillEffectType);          <ITEMS IS NOT GOING TO APPLY DAMAGE VARIATION>
            
            var damageAppliedAlteredStateModifier = BattleAlteredStateBonusCalculator.CalculateApplyDamageModifier(sourceState, skillEffectType);
            var damageReceivedAlteredStateModifier = BattleAlteredStateBonusCalculator.CalculateReceivedDamageModifier(targetState, skillEffectType);

            var bonusMultiplier = 1 + (damageAppliedAlteredStateModifier + damageAppliedItemModifier +
                             damageReceivedAlteredStateModifier + damageReceivedItemModifier);
            
            var baseDamage = sourceState.GetCurrentAttribute(EntityAttributesConstants.STRENGTH, 1f) * actionParamsBaseSkillHealthVariation;
            return baseDamage * bonusMultiplier;
        }

        public static float CalculateHeal(IUnitEntityState sourceState, IUnitEntityState targetState, float actionParamsBaseSkillHealthVariation, string actionParamsSkillEffectType)
        {
            return actionParamsBaseSkillHealthVariation;
        }
    }
}