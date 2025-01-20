using System.Collections.Generic;

namespace Skills.Ports
{
    public interface ISkillEffectData
    {
        public string AlteredStateToApply { get; }
        public IEnumerable<ISkillEffectDamageTerm> DamageEffectData { get; }
    }
}