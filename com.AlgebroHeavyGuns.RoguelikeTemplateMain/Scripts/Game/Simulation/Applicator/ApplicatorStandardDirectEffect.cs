using System;
using System.Collections.Generic;
using Game.Simulation.Params;
using Game.Simulation.Services;
using Simulation.Ports;
using UnityEngine.Assertions;

namespace Game.Simulation.Applicator
{
    public class ApplicatorStandardDirectEffect : IActionApplicator<SimulationApplicatorParams.DirectHealthModification>
    {
        public void Apply(IBoardState boardState, SimulationApplicatorParams.DirectHealthModification actionParams)
        {
            Apply(boardState, actionParams, ApplyHealthVariation);
            return;

            void ApplyHealthVariation(IUnitEntityState target, float healthVariation) 
            {
                boardState.ApplyCurrentHealthVariationTo(new ApplicationParams.HealthVariationParams()
                    { UnitSourceId = actionParams.UnitSourceId, UnitTargetId = actionParams.UnitTargetId, HealthVariation = healthVariation, EffectType = actionParams.SkillEffectType,});
            }
        }
        

        public IEnumerable<(IUnitEntityState, float)> GetPreview(IBoardState boardState, SimulationApplicatorParams.DirectHealthModification actionParams)
        {
            var previewUnits = new List<(IUnitEntityState, float)>();
            Apply(boardState, actionParams, SavePreview);
            return previewUnits;

            void SavePreview(IUnitEntityState target, float healthVariation)
            {
                previewUnits.Add(new ValueTuple<IUnitEntityState, float>(target, healthVariation));
            }
        }

        private static void Apply(IBoardState boardState, SimulationApplicatorParams.DirectHealthModification actionParams, Action<IUnitEntityState, float> applicationAction)
        {
            var result = boardState.TryGetUnitWithId(actionParams.UnitSourceId, out var sourceState);
            Assert.IsTrue(result);
            result = boardState.TryGetUnitWithId(actionParams.UnitTargetId, out var targetState);
            Assert.IsTrue(result);
            
            var healthVariation = BattleEffectTypeFilter.IsDamage(actionParams.SkillEffectType) 
                ? BattleEffectAmountCalculator.CalculateDamage(sourceState, targetState, actionParams.BaseSkillHealthVariation, actionParams.SkillEffectType) 
                : BattleEffectAmountCalculator.CalculateHeal(sourceState, targetState, actionParams.BaseSkillHealthVariation, actionParams.SkillEffectType);
            
            applicationAction.Invoke(targetState, healthVariation);
        }
    }
}