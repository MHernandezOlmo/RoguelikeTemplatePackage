using Simulation.Ports;

namespace Game.Simulation.Services
{
    public static class BattleAlteredStateBonusCalculator
    {
        public static float CalculateApplyDamageModifier(IUnitEntityState sourceState, string skillEffectType)
        {
            var baseMultiplier = 0f;
            if (sourceState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_50%_ BONUS", out _)) baseMultiplier += 0.5f;
            if (sourceState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_25%_ BONUS", out _)) baseMultiplier += 0.25f;
            if (sourceState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_10%_ACCUMULATION_BONUS", out var accumulations)) baseMultiplier += 0.1f * accumulations;
            if (sourceState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_50%_IF_WATER_DAMAGE", out _) && skillEffectType.Equals("WATER")) baseMultiplier += 0.5f; 

            return baseMultiplier;
        }
        public static float CalculateReceivedDamageModifier(IUnitEntityState targetState, string skillEffectType)
        {
            var baseMultiplier = 0f;
            if (targetState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_50%_ DEFEND_BONUS", out _)) baseMultiplier -= 0.5f;
            if (targetState.TryGetAlteredStateAccumulations("EXAMPLE_STATE_50%_ WEAKNESS_BONUS", out _)) baseMultiplier += 0.5f;
            return baseMultiplier;
        }

        public static bool IsBlockingDamage(IUnitEntityState targetState, string skillEffectType)
        {
            if(targetState.TryGetAlteredStateAccumulations("EXAMPLE_NO_DAMAGE_SHIELD", out _)) return true;
            if(targetState.TryGetAlteredStateAccumulations("EXAMPLE_FIRE_DAMAGE_CANCELING", out _) && skillEffectType.Equals("FIRE")) return true;
            return false;
        }

        public static bool HasDamageBlocked(IUnitEntityState sourceState, string skillEffectType)
        {
            if (sourceState.TryGetAlteredStateAccumulations("EXAMPLE_CANT_DO_DAMAGE", out _)) return true;
            return false;
        }
    }
}