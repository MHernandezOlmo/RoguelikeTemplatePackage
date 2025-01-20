using System.Collections.Generic;

namespace Skills.Ports
{
    public interface ISkillsSystem
    {
        bool TryGetSkill(int key, out ISkillModel unitModel);
        IEnumerable<ISkillModel> GetAllSkills();
    }
}