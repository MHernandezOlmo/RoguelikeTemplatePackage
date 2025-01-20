using Skills.Ports;

namespace Skills
{
    public class SkillModel : ISkillModel
    {
        public ISkillStaticData StaticData { get; }

        public SkillModel(ISkillStaticData staticData)
        {
            StaticData = staticData;
        }
    }
}