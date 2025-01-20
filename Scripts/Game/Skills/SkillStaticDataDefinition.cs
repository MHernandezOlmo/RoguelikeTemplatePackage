using System;
using System.Collections.Generic;
using System.Linq;
using Skills.Ports;
using UnityEngine;

namespace Game.Skills
{
    [CreateAssetMenu(menuName = "Game/Skills/Definition", fileName = "SkillStaticDataDefinition", order = 0)]
    public class SkillStaticDataDefinition : ScriptableObject
    {
        [SerializeField] private string skillForename;
        [SerializeField] private string imageKey;
        [SerializeField] private SkillEffectDefinition effectDefinition;
        
        public string Forename => skillForename;
        public string ImageKey => imageKey;
        public ISkillEffectData EffectData => effectDefinition;
    }
    
    [Serializable]
    public class SkillEffectDefinition : ISkillEffectData
    {
        [SerializeField] private string alteredStateDefinition = "NONE";
        [SerializeField] private EffectTermDefinition[] damageEffects;
        
        public string AlteredStateToApply => alteredStateDefinition;
        public IEnumerable<ISkillEffectDamageTerm> DamageEffectData => damageEffects;
            
        [Serializable]
        public class  EffectTermDefinition : ISkillEffectDamageTerm
        {
            public EffectValueWord[] ValueWords;
            public string damageType;

            public IEnumerable<KeyValuePair<int, float>> EffectTerm => ValueWords.Select(word =>
                new KeyValuePair<int, float>(GetAttributeHashCode(word.AttributeKey), word.Value));

            private int GetAttributeHashCode(string attributeKey)
            {
                return string.IsNullOrWhiteSpace(attributeKey) ? SkillDamageEffectCalculator.EMPTY_HASH_CODE : attributeKey.GetHashCode();
            }
        }
    
        [Serializable]
        public struct EffectValueWord
        {
            public string AttributeKey;
            public float Value;
        }
    }


}