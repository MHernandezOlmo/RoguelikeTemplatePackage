using Entities.Ports;
using Skills.Ports;


namespace Game.Skills
{
    public static class SkillDamageEffectCalculator
    {
        public const int EMPTY_HASH_CODE = -1;
        public static float CalculateDamageFromAttributes(IEntityModel entityModel, ISkillEffectDamageTerm skillEffectDamageTerm)
        {
            var damage = 0f;
            foreach (var (attributeKey, value) in skillEffectDamageTerm.EffectTerm)
            {
                if (attributeKey == EMPTY_HASH_CODE)
                    damage += value;
                else if (entityModel.TryGetCurrentAttribute(attributeKey, out var currentAttributeValue))
                    damage += currentAttributeValue * value;
            }
            return damage;
        }
    }
}