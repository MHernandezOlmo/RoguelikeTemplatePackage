using Skills.Ports;

namespace Game.Skills
{
    public class SkillStaticData : ISkillStaticData
    {
        public int Id { get; }
        public string ImageKey { get; }
        public ISkillEffectData EffectData { get; }
        public string Forename { get; }
        

        public SkillStaticData(SkillStaticDataDefinition skillStaticDataDefinition)
        {
            Id = skillStaticDataDefinition.Forename.GetHashCode();
            Forename = skillStaticDataDefinition.Forename;
            ImageKey = skillStaticDataDefinition.ImageKey;
            EffectData = skillStaticDataDefinition.EffectData;
        }
    }
}