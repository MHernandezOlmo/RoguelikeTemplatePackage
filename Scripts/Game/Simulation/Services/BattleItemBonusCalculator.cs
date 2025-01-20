using Battle.Ports;
using Game.Inventory;
using Simulation.Ports;

namespace Game.Simulation.Services
{
    public static class BattleItemBonusCalculator
    {
        public static float CalculateApplyDamageModifier(IUnitEntityState sourceState, string skillEffectType)
        {
            var bonus = 0f;
            //If you want to apply items bonuses to player units only.
            if (sourceState.Team != (uint)IBattleSettings.Team.PLAYER) return bonus;

            bonus += UserInventoryToBonusConverter.GetBonus("EXAMPLE_DAMAGE_BONUS");
            
            return bonus;
        }

        public static float CalculateReceivedDamageModifier(IUnitEntityState targetState, string skillEffectType)
        {
            //If you want to apply items bonuses to player units only.
            if (targetState.Team != (uint)IBattleSettings.Team.PLAYER) return 0f;

            return 0f;
        }
    }
}