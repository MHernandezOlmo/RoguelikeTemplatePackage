using System.Collections.Generic;

namespace Skills.Ports
{
    public interface ISkillEffectDamageTerm
    {
        public IEnumerable<KeyValuePair<int, float>> EffectTerm { get; } 
    }
}