using System.Collections.Generic;
using System.Linq;
using Common;
using Skills.Ports;

namespace Skills
{
    public class SkillsSystem : ISkillsSystem
    {
        private Dictionary<int, SkillModel> skillModels;
        private ISkillStaticDataRepository skillStaticDataRepository;

        public void SetData(ISkillStaticDataRepository skillStaticDataRepository)
        {
            this.skillStaticDataRepository = skillStaticDataRepository;
        }

        public void Initialize()
        {
            skillModels = skillStaticDataRepository.GetElements().ToDictionary(
                x => x.Id, 
                x => new SkillModel(x));
        }

        public void Dispose()
        {
            skillModels.Clear();
            skillModels = null;
        }

        public bool TryGetSkill(int key, out ISkillModel unitModel)
        {
            unitModel = null;
            if(!skillModels.TryGetValue(key, out var model)) return false;
            unitModel = model;
            return true;
        }

        public IEnumerable<ISkillModel> GetAllSkills()
        {
            return skillModels.Values;
        }

    }
}
